using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;
    private PlayerMovement coins;
    public static float Score = 0.0f;
    private int _difficultyLevel = 1;
    private int _maxDifficulty = 20;
    private int _scoreToNextLevel = 12;
  
    private bool isDead;
    

    public void Update()
    {
        if (Score >= _scoreToNextLevel)
        {
            LevelUp();
        }

        Score += Time.deltaTime * _difficultyLevel;
        
        ScoreText.text = ((int)Score).ToString();
    }

    public void LevelUp()
    {
        if (_difficultyLevel == _maxDifficulty)
        {
            return;
        }

        _scoreToNextLevel *= 2;
        _difficultyLevel++;
        GetComponent<PlayerMovement>().SetSpeed(_difficultyLevel);
    }

    public void OnDeath()
    {
        isDead = true;
               
    }
}
