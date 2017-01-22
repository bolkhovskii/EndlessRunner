using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ScoreManager : MonoBehaviour {
    private float Score = 0.0f;
    public Text scoreText;

    private int difficultyLevel = 1;
    private int maxDifficulty = 20;
    private int scoreToNextLevel = 12;

	// Use this for initialization
	void Start () {
        //проверка
        GameManager.instance.AdjustScore(1350);
        ///
	}

    // Update is called once per frame
    void Update () {

        if (Score >= scoreToNextLevel)
            LevelUp();

        Score += Time.deltaTime * difficultyLevel;

        

        scoreText.text = ((int)Score).ToString();
	
	}

    private void LevelUp()
    {
        if (difficultyLevel == maxDifficulty)
            return;

        scoreToNextLevel *= 2;
        difficultyLevel++;
        Debug.Log(difficultyLevel);
        GetComponent<PlayerMovement>().SetSpeed(difficultyLevel);
    }
}
