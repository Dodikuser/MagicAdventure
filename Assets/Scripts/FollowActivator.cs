using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowActivator : MonoBehaviour
{
    public FollowEntity Script;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player") Script.Init(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player") Script.Disable();
    }
}
