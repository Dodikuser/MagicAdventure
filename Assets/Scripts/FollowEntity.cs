using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowEntity : MonoBehaviour
{
    public GameObject ThisObject;
    public GameObject FollowObject;

    public float Speed;
    public float MinDistance = 2f;
    
    private void FixedUpdate()
    {
        Vector3 direction = ThisObject.transform.position - FollowObject.transform.position ;
        float distance = direction.magnitude;

        if (distance > MinDistance)
        {        
            ThisObject.transform.Translate(Vector3.forward * Speed * Time.fixedDeltaTime);
        }

        ThisObject.transform.LookAt(FollowObject.transform);
    }

    public void Init(GameObject followObject)
    {
        FollowObject = followObject;
        enabled = true;
    }
    public void Disable()
    {
        enabled = false;
    }
}
