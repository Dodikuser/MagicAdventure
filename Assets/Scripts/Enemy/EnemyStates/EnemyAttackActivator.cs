using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackActivator : MonoBehaviour
{
    public Enemy Enemy;
    public Collider FollowColider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            FollowColider.enabled = false;

            Enemy.Attack.Active = true;
            Enemy.Attack.Init(Enemy.gameObject, other.gameObject);
            Enemy.SetState(Enemy.Attack);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            FollowColider.enabled = true;

            Enemy.Attack.Active = false;
            Enemy.SetState(Enemy.FollowPlayer);
        }
    }
}
