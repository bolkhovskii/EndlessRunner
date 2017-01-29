using UnityEngine;
using Assets.Scripts.Core;

public class PlayerMovement : MonoBehaviour, IPlayerMovement
{

    [SerializeField]
    private CharacterController _controller;
    private float _speed = 5.0f;
    private float _jumpSpeed = 7f;
    private float _gravity = 9.81f;
    private Vector3 _moveVector;
    private float _verticalVelocity = 0.0f;
    private int _coinCounter;

    public PlayerMovement()
    {
        _coinCounter = 1;
    }
    public void Start()
    {
        _controller = GetComponent<CharacterController>();
        _moveVector = Vector3.zero;
    }
    
    public void Update()
    {
        Run();
    }

    public void Run()
    {
        //x right and left
        _moveVector.x = Input.GetAxisRaw("Horizontal") * _speed;
        //y up and down

        if (_controller.collisionFlags != CollisionFlags.Below)
        {
            if (_controller.collisionFlags == CollisionFlags.Sides)
            {
                //TODO: Collision with objects
            }
        }

        if (Input.GetButton("Jump"))
        {
            if (_controller.isGrounded)
            {
                _moveVector.y = _jumpSpeed;
            }
        }
        else
        {
            _moveVector.y -= _gravity * Time.deltaTime;
        }
        
        //moveVector.y = verticalVelocity;

        //z forward and backward
        _moveVector.z = _speed;

        _controller.Move(_moveVector * Time.deltaTime);
    }

    public void SetSpeed(float modifier)
    {
        _speed = 5.0f + modifier;
    }
}
