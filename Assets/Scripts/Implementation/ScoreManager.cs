using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using Assets.Scripts.Core;
using Assets.Scripts.Utils;

public class ScoreManager : MonoBehaviour, IScoreManager
{
    public ManagerStatus status { get; private set; }
    public Text ScoreText;

    private float _score = 0.0f;
    private int _difficultyLevel = 1;
    private int _maxDifficulty = 20;
    private int _scoreToNextLevel = 12;

    // Use this for initialization
    public void Start()
    {
        //проверка
        GameManager.instance.AdjustScore(1350);
        ///
	}

    // Update is called once per frame
    public void Update()
    {
        if (_score >= _scoreToNextLevel)
        {
            LevelUp();
        }

        _score += Time.deltaTime * _difficultyLevel;

        ScoreText.text = ((int)_score).ToString();
    }

    public void LevelUp()
    {
        if (_difficultyLevel == _maxDifficulty)
        {
            return;
        }

        _scoreToNextLevel *= 2;
        _difficultyLevel++;
        
        Debug.Log(_difficultyLevel);
        GetComponent<PlayerMovement>().SetSpeed(_difficultyLevel);
    }

    public void Startup()
    {

    }
}
