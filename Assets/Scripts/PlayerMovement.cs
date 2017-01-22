using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    
    [SerializeField]
    private CharacterController controller;
    private float speed=5.0f;
    private float jumpSpeed = 7f;
    private float gravity = 9.81f;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        moveVector = Vector3.zero;
    }


    private void Update()
    {
        Run();
    }

	void Run () {



        //x right and left
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        //y up and down

        if (Input.GetButton("Jump"))
        {
            if (controller.isGrounded)
            {
                moveVector.y = jumpSpeed;
            }
        }
        else
        {
            moveVector.y -= gravity * Time.deltaTime;
        }

           

        //moveVector.y = verticalVelocity;

        //z forward and backward
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
	}

    public void SetSpeed(float modifier)
    {
        speed = 5.0f + modifier;
    }
}
