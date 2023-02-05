using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //public UIController gameover;
    private Animator _playerAnim;
    private Rigidbody rb;
    private Vector3 direction;


    [SerializeField] private DynamicJoystick _dynamicJoystick;
    
   
    public float speed;
    public float turnSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
       _playerAnim = GetComponent<Animator>();
    }

    public void FixedUpdate()
    {
      

        if (Input.GetMouseButton(0))
        {
            JoystickMovement();
            _playerAnim.SetBool("IsMoving", true);

        }
        else
        {
            _playerAnim.SetBool("IsMoving", false);
        }
    }

    private void JoystickMovement()
    {
        float horizontal = _dynamicJoystick.Horizontal;
        float vertical = _dynamicJoystick.Vertical;
        Vector3 addedPos = new Vector3(horizontal*speed*Time.deltaTime, 0 ,vertical*speed*Time.deltaTime);
        transform.position += addedPos;

        direction= Vector3.forward*vertical + Vector3.right * horizontal;
        transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(direction),turnSpeed * Time.deltaTime);


    }


    //this is where they collide with the trigger collider at ends of the platform and it triggers to loading the same scene
    private void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "GameOver")
        {
            UIController.instance.RestartGame();
            print("platform collider triggered");
        }
    }

   

}
