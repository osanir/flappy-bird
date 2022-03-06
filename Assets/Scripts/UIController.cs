using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("Tutorial Elements")]
    [SerializeField] Image tapToPlayImage;
    [SerializeField] Image getReadyImage;
    [SerializeField] GameObject tutorialObject;
    [SerializeField] TextMeshProUGUI scoreText;

    [Header("GameOver Elements")]
    [SerializeField] TextMeshProUGUI gameOverScoreText;
    [SerializeField] TextMeshProUGUI gameOverHighScoreText;
    [SerializeField] Image gameOverMedalImage;
    [SerializeField] Image gameOverPanelImage;
    [SerializeField] GameObject gameOverObject;


    GameStateController gameStateController;

    private void Start()
    {
        gameStateController = FindObjectOfType<GameStateController>();

        StartCoroutine(FadeAnimation());
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
        gameOverScoreText.text = score.ToString();
    }

    public void UpdateHighScoreText(int highScore)
    {
        gameOverHighScoreText.text = highScore.ToString();
    }

    public void EnableGameOverPanel()
    {
        gameOverObject.active = true;
    }

    IEnumerator FadeAnimation()
    {
        while (gameStateController.IsTutorial())
        {
            float alpha = Mathf.Sin(Time.time);
            Debug.Log(alpha);
            tapToPlayImage.color = new Color(1, 1, 1, Mathf.Abs(alpha));
            yield return new WaitForEndOfFrame();
        }
        tutorialObject.active = false;
    }
}
