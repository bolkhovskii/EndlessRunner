using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private int _currentScore;
    public static GameManager instance = null;
    public LevelManager levelScript;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
        levelScript = GetComponent<LevelManager>();
        InitGame();
        //проверка создания 
        Debug.Log("Game init");
    }

    private void InitGame()
    {
        levelScript.CreateGame();
    }

    public void AdjustScore(int num)
    {
        _currentScore += num;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), "Score is " + _currentScore);
    }
}

