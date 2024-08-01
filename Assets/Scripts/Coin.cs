using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IDestroyable
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().GiveCoins(1);
            DestroyEvent();
        }
    }

    public static void CreateCoin(Vector3 position)
    {
        Instantiate(PrefabContainer.Instance.Coin, position, Quaternion.Euler(0, 0, 90));
    }

    public void DestroyEvent()
    {
        Destroy(gameObject);
    }

}
