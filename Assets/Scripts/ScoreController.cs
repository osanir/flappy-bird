using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] int highScore;
    [SerializeField] int score;

    UIController uiController;

    private void Start()
    {
        uiController = FindObjectOfType<UIController>();
        highScore = PlayerPrefs.GetInt("highScore", 0);
        uiController.UpdateHighScoreText(highScore);
    }

    public void ResetScore()
    {
        score = 0;
        uiController.UpdateScoreText(score);
    }

    public void AddScore(int amount)
    {
        score += amount;
        uiController.UpdateScoreText(score);
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
            uiController.UpdateHighScoreText(highScore);
        }
    }

    public float GetScore()
    {
        return score;
    }

    internal void EarnPipeScore()
    {
        AddScore(1);
    }
}
