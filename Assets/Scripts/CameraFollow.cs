using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
   
    private Transform _lookAt;
    private Vector3 _startOffset;
    private Vector3 _moveVector;
    private float _transition;
    private float _animationDuration = 2.0f;
    private Vector3 _animationOffset = new Vector3(0, 5, 5);
    private bool StartGame;


    // Use this for initialization
    public void Start()
    {
        StartGame = false;
    }

    public void StartLook()
    {
        _lookAt = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _startOffset = transform.position - _lookAt.position;
        StartGame = true;
    }
    // Update is called once per frame
    public void Update()
    {
        if (StartGame)
        {
            _moveVector = _lookAt.position + _startOffset;
            //X
            _moveVector.x = 0;
            //Y
            _moveVector.y = Mathf.Clamp(_moveVector.y, 3, 5);

            if (_transition > 1.0f)
            {
                transform.position = _moveVector;
            }
            else
            {
                //animation at the start of the game
                transform.position = Vector3.Lerp(_moveVector + _animationOffset, _moveVector, _transition);
                _transition += Time.deltaTime * 1 / _animationDuration;
            }
        }
    }
}
