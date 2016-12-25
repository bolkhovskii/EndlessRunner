﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;
    private float transition;
    private float animationDuration=2.0f;
    private Vector3 animationOffset = new Vector3(0, 5, 5);

	// Use this for initialization
	void Start () {
        lookAt = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        startOffset = transform.position - lookAt.position;
	}
	
	// Update is called once per frame
	void Update () {


        moveVector = lookAt.position + startOffset;
        //X
        moveVector.x = 0;
        //Y
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);

        if (transition > 1.0f)
        {
            transform.position = moveVector;
        }
        else
        {
            //animation at the start of the game
            transform.position = Vector3.Lerp(moveVector+ animationOffset, moveVector,transition);
            transition += Time.deltaTime * 1 / animationDuration;
        }
	}
}
