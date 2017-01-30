using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;
    public PlayerMovement thePlayer;
    public GameObject animator;
    private Vector3 playerStartPoint;
    private LevelDestroyer[] theObjects;
    private ScoreManager theScoreManager;
    public GameObject tapToPlayButton;
    public DeathMenu theDeathMenu;
    public GameObject thePauseButton;

    // Use this for initialization
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        theScoreManager = FindObjectOfType<ScoreManager>();
        animator.SetActive(false);

    }

    public void RestartGame()
    {

      
        thePlayer.gameObject.SetActive(false);

        theDeathMenu.gameObject.SetActive(true);
        thePauseButton.gameObject.SetActive(false);
        tapToPlayButton.gameObject.SetActive(false);
    }

    public void Reset()
    {
        theDeathMenu.gameObject.SetActive(false);
        thePauseButton.gameObject.SetActive(true);
        theObjects = FindObjectsOfType<LevelDestroyer>();
        for (int i = 0; i < theObjects.Length; i++)
        {
            theObjects[i].gameObject.SetActive(false);
        }
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        PlayGame();
    }

    public void PlayGame()
    {
        thePlayer._speed = 3;
        thePlayer._jumpSpeed = 10;
        theScoreManager.ScoreText.text = "0";
        thePlayer._coinCounter = 0;
        animator.SetActive(true);
        tapToPlayButton.gameObject.SetActive(false);
        thePauseButton.gameObject.SetActive(true);
    }

}
