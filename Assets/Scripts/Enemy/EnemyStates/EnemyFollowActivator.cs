using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowActivator : MonoBehaviour
{
    public Enemy Enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Enemy.FollowPlayer.Init(Enemy.gameObject, other.gameObject);
            Enemy.SetState(Enemy.FollowPlayer);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player") 
            Enemy.SetState(Enemy.Rest);
    }
}
