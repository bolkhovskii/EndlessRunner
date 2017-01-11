using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour, IGameManager {
    public ManagerStatus status { get; private set; }
    [SerializeField]
    private CharacterController controller;
    private float speed=5.0f;
    private float gravity = 9.81f;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;


	public void Startup () {
        Debug.Log("Player manager starting...");
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();

        status = ManagerStatus.Started;
        //Run();
	
	}

    private void Update()
    {
        Run();
    }

	void Run () {

        moveVector = Vector3.zero;

        if (controller.isGrounded) {
            verticalVelocity = -0.5f;
        } else {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        //x right and left
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        //y up and down
        moveVector.y = verticalVelocity;
        //z forward and backward
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
	}

    public void SetSpeed(float modifier)
    {
        speed = 5.0f + modifier;
    }
}
