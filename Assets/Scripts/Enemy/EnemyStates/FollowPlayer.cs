using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/FollowPlayerState")]
public class FollowPlayer : State
{
    public GameObject ThisObject;
    public GameObject FollowObject;
    private Enemy Script;

    public float Speed;
    public float MinDistance = 2f;

    public override void Run()
    {
        Vector3 direction = ThisObject.transform.position - FollowObject.transform.position;
        float distance = direction.magnitude;

        if (distance > MinDistance)
        {
            ThisObject.transform.Translate(Vector3.forward * Speed * Time.fixedDeltaTime);
        }

        ThisObject.transform.LookAt(FollowObject.transform);
    }

    public override void Init(GameObject thisObject, GameObject followObject)
    {
        IsLoop = true;
        FollowObject = followObject;
        ThisObject = thisObject;
        Script = ThisObject.GetComponent<Enemy>();

        Script.Animator.SetTrigger("Follow");
    }
    
}
