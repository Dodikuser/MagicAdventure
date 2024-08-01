using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour, IDestroyable
{
    [SerializeField] protected float Speed;
    [SerializeField] protected float Damage = 3f;    
    
    private Weapon _weapon;
    private GameObject _closestEnemy = null;

    public GameObject ImpactParticles;
    public List<ParticleSystem> Particles;

    private void FixedUpdate()
    {
        if (_closestEnemy == null) _closestEnemy = GetClosestEnemy(transform.position);

        transform.Translate(Vector3.forward * Speed * Time.fixedDeltaTime);
        if (_closestEnemy != null) transform.LookAt(_closestEnemy.transform.position);
        else _weapon.Active = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;
        if (tag == "Enemy" || tag == "Obs") 
        {
            if (tag == "Enemy") other.GetComponent<Enemy>().TakeDamage(Damage);
            DestroyEvent();
        }
    }

    public virtual void Init(Weapon weapon)
    {
        _weapon = weapon;
        _closestEnemy = GetClosestEnemy(transform.position);
    }

    public static GameObject GetClosestEnemy(Vector3 position)
    {
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in Player.EnemysISee)
        {
            if (enemy != null)
            {
                float distance = Vector3.Distance(position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }
        }
        Player.ClosestEnemy = closestEnemy;
        return closestEnemy;
    }

    public virtual void DestroyEvent()
    {
        Instantiate(ImpactParticles, transform.position, Quaternion.identity);
        enabled = false;
        GetComponent<Collider>().enabled = false;

        foreach(var p in Particles)
        {
            p.Stop();
        }
        Invoke("DestroyProjectile", 1f);
    }
    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
