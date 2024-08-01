using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour, IDestroyable
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().GiveWood(1);
            DestroyEvent();
        }
    }

    public static void CreateWood(Vector3 position)
    {
        Instantiate(PrefabContainer.Instance.Wood, position, Quaternion.Euler(0, 0, 90));
    }

    public void DestroyEvent()
    {
        Destroy(gameObject);
    }
}
