using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBMovement : MonoBehaviour
{
     public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f; 
    Vector3 velocity;

    public Transform groundCheck;
    public Transform characterTransform;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    public LayerMask groundMask2;
    bool isGrounded;

    // jumping
    public float jumpForce = 20f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask)||
                     Physics.CheckSphere(groundCheck.position, groundDistance, groundMask2);

        if (isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal_2");
        float z = Input.GetAxis("Vertical_2");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // jumping
        //test//
        if (Input.GetKeyDown(KeyCode.P)){
            Debug.Log("P is pressed");
        }
        //

       if (Input.GetKeyDown(KeyCode.P) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * velocity.y * gravity);
            Debug.Log("Jump");
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //
    

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    }
    
