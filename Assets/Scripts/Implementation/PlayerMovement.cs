using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private CharacterController _controller;
    private Animator animator;
    public float _speed = 0.0f;
    public float _jumpSpeed = 7f;
    private float _gravity = 9.81f;
    private Vector3 _moveVector;
    private float _verticalVelocity = 0.0f;
    public int _coinCounter;
    public Text CoinsCounter;
    public Text LivesCounter;
    private int _livesCounter;
    private bool _isDead = false;
    [SerializeField]
    private ScoreManager score;
    public DeathMenu deathMenu;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private AudioSource jump;
    [SerializeField]
    private AudioSource diesound;

    public PlayerMovement()
    {
        _coinCounter = 1;
        _livesCounter = 5;
    }
    public void Start()
    {
        animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
        _moveVector = Vector3.zero;
    }

    public void Update()
    {

        Run();
      
    }

    public void Run()
    {
        if (_speed != 0) { 
        _moveVector.x = Input.GetAxisRaw("Horizontal") * _speed/2;

        if (Input.GetButton("Jump"))
        {
            if (_controller.isGrounded)
            {
                    jump.Play();
                _moveVector.y = _jumpSpeed;
                    animator.SetBool("isJump", true);
            }
        }
        else
        {
            _moveVector.y -= _gravity * Time.deltaTime;
                animator.SetBool("isJump", false);

            }
            _moveVector.z = _speed;
        _controller.Move(_moveVector * Time.deltaTime);
    }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("coin"))
        {
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

       if ((hit.point.y > transform.position.y + _controller.radius)&& (hit.collider.tag != "coin"))
        {
            _livesCounter--;
            LivesCounter.text = ((int)_livesCounter).ToString();
            _isDead = false;

            if (_livesCounter <= 0)
            {
                _isDead = true;
                Player.SetActive(false);
                diesound.Play();
                deathMenu.ToggleEndMenu(ScoreManager.Score, _coinCounter, true);
            }

        }
    }

    public void SetSpeed(float modifier)
    {
        _speed = _speed/2 + modifier;
    }
}