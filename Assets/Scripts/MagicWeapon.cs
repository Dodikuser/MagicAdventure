using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MagicWeapon : Weapon
{
    [SerializeField] protected GameObject ProjectileObject;

    private Coroutine attackCoroutine;
    public PlayerControler PlayerControler;
    

    private void Start()
    {
        //StartAttack();
    }
    
    public override IEnumerator Fire()
    {
        while (Active)
        {
            if (PlayerControler.joystickInput == Vector2.zero)
            {
                //Projectile.GetClosestEnemy(transform.position);
                PlayerControler.LookAtEnemy.Target = Player.ClosestEnemy;
                PlayerControler.LookAtEnemy.enabled = true;
                SpawnProjectile();            
            }           
            yield return new WaitForSeconds(1 / SpeedAttack);
        }
        attackCoroutine = null;
    }
    protected virtual void SpawnProjectile()
    {
        GameObject projectile = Instantiate(ProjectileObject, _shootPoint.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().Init(this);
    }
    public override void StartAttack()
    {
        if (attackCoroutine == null)
        {
            attackCoroutine = StartCoroutine(Fire());
        }
    }
}
