using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Core;
using System;
using UnityEditor;

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
    public Text CoinsCounter;
    public Text LivesCounter;
    private int _livesCounter;
    private bool _isDead = false;

    public PlayerMovement()
    {
        _coinCounter = 1;
        _livesCounter = 5;
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

        //z forward and backward
        _moveVector.z = _speed;
        _controller.Move(_moveVector * Time.deltaTime);
    }

<<<<<<< HEAD
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("coin"))
        {
            Destroy(collider.gameObject);
            CoinsCounter.text = ((int)_coinCounter++).ToString();
            ScoreManager.Score += 50;
        }

        if (collider.gameObject.name.Contains("Cube (1)"))
        {
            Debug.Log(collider.gameObject.name);
        }
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //if (hit.collider.gameObject.tag == "coin") {
        //    hit.controller.detectCollisions = false;
        //}

       if ((hit.point.z > transform.position.z + _controller.radius)&& (hit.collider.tag != "coin"))
        {
            _livesCounter--;
            LivesCounter.text = ((int)_livesCounter).ToString();
            _isDead = false;

            if (_livesCounter == 0)
            {
                _isDead = true;
                Death();
            }

        }
    }

    private void Death()
    {
        Debug.Log("Death");
        EditorApplication.isPaused = true;
    }

=======
>>>>>>> Final
    public void SetSpeed(float modifier)
    {
        _speed = 5.0f + modifier;
    }
}
