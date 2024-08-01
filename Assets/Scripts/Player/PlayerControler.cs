using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    public LookAt LookAtEnemy;

    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;

    public Vector2 joystickInput;

    private void OnDisable()
    {
        MainLinks.Instance.StartCounter.StartGame -= StartController;
    }
    private void Awake()
    {
        //enabled = false;
        MainLinks.Instance.StartCounter.StartGame += StartController;
    }

    void Update()
    {
        joystickInput = new Vector2(joystick.Horizontal, joystick.Vertical);
    }
    private void FixedUpdate()
    {
        if (this.joystickInput == null) return;
        
        if (joystickInput.magnitude > 0.1f)
        {          
            if(LookAtEnemy.enabled) LookAtEnemy.enabled = false;
            joystickInput.Normalize();

            Vector3 moveDirection = new Vector3(joystickInput.x, 0, joystickInput.y);

            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
            
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime * 100);
        }
    }

    private void StartController()
    {
        enabled = true;
    }
}
