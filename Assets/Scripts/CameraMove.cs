using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Player;
    public Vector3 offset;

    void FixedUpdate()
    {
        transform.position = Player.transform.position + offset;
    }
}
