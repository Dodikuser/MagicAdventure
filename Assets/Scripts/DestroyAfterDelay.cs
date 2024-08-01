using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour, IDestroyable
{
    [SerializeField] private float _delay = 1f;

    void Start()
    {
        Invoke("DestroyEvent", _delay);
    }

    public void DestroyEvent()
    {
        Destroy(gameObject);
    }
}
