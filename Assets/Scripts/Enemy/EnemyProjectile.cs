using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    public GameObject PlayerObject;
    private Vector3 _direction;

    private void FixedUpdate()
    {
        if (PlayerObject == null) return;

        transform.Translate(Vector3.forward * Speed * Time.fixedDeltaTime);
        //if (PlayerObject != null) transform.LookAt(_playerPosition);
        transform.rotation = Quaternion.LookRotation(_direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;
        if (tag == "Player" || tag == "Obs")
        {
            if (tag == "Player") other.GetComponent<Player>().TakeDamage(Damage);
            DestroyEvent();
        }
    }
    public void Init(GameObject playerObject)
    {
        PlayerObject = playerObject;
        Vector3 _playerPosition = PlayerObject.transform.position;
        _direction = _playerPosition - transform.position;
        _direction.Normalize();
        Quaternion.LookRotation(_direction);
    }
    public override void DestroyEvent()
    {
        Instantiate(PrefabContainer.Instance.EnemyProjectileImpact, transform.position, transform.rotation);
        Destroy(transform.gameObject);
    }
}
