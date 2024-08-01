using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMagnet : FollowEntity
{
    private void FixedUpdate()
    {
        Vector3 direction = (FollowObject.transform.position - transform.position).normalized;
        Vector3 newPosition = transform.position + direction * Speed * Time.deltaTime;
        transform.position = newPosition;
    }
}
