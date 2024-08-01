using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceAttakActivator : MonoBehaviour
{
    public SliceAttak ScriptAttak;

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;
        if (tag == "Player")
        {
            ScriptAttak.Attack(other.GetComponent<IDamageable>());
        }
    }
}
