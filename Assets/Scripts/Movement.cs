using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameStateController;

public class Movement : MonoBehaviour
{
    [Header("Bird Properties")]
    [SerializeField] float speed = 0;
    [SerializeField] float fallAnimationSpeed = 0;
    [SerializeField] float flapStrength = 12f;
    [SerializeField] float gravity = 0.5f;

    [Header("Sine Properties")]
    [SerializeField] float sineAmplitude = 0.75f;
    [SerializeField] float sineSpeed = 3f;
    [SerializeField]
    Animator animator;

    CircleCollider2D birdCollider;

    TouchControls touchControls;
    GameStateController gameStateController;
    AudioController audioController;
    ScoreController scoreController;
    UIController uiController;


    bool isTouched = false;
    float defaultGravity;

    private void Start()
    {
        Application.targetFrameRate = 60;
        touchControls = GetComponent<TouchControls>();
        birdCollider = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();

        gameStateController = FindObjectOfType<GameStateController>();
        audioController = FindObjectOfType<AudioController>();
        scoreController = FindObjectOfType<ScoreController>();
        uiController = FindObjectOfType<UIController>();

        defaultGravity = gravity;
        gravity = 0;

        StartCoroutine(PlayVerticalSineMovement());

    }

    void Update()
    {
        switch (gameStateController.GetGameState())
        {
            case GameState.TUTORIAL:
                {
                    if (Input.GetMouseButtonDown(0) || (touchControls.CanFlap && touchControls.TouchState))
                    {
                        gravity = defaultGravity;
                        animator.SetBool("isTutorial", false);
                        Flap();
                        gameStateController.SetGameState(GameState.PLAY);
                    }
                    break;
                }
            case GameState.PLAY:
                {
                    ApplyGravity();
                    if (Input.GetMouseButtonDown(0) || (touchControls.CanFlap && touchControls.TouchState))
                    {
                        Flap();
                    }
                    break;
                }
            case GameState.GAMEOVER:
                {

                    break;
                }
        };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleCollisionEvents(collision.gameObject.tag);
    }

    private void HandleCollisionEvents(string tag)
    {
        switch (tag)
        {
            case "Ground":
            case "Pipe":
                {
                    if (!gameStateController.IsGameOver())
                    {
                        gameStateController.SetGameState(GameState.GAMEOVER);
                        audioController.PlaySFXHit();
                        uiController.EnableGameOverPanel();
                        StartCoroutine(PlayFallAnimation());
                        StartCoroutine(RestartGame());
                    }
                    break;
                }
            case "ScoreArea":
                {
                    scoreController.EarnPipeScore();
                    audioController.PlaySFXPoint();
                    Debug.Log("Score area!");
                    break;
                }
        };
    }

    private void ApplyGravity()
    {
        Vector2 newPosition = transform.position;
        speed += gravity ;
        newPosition.y -= speed * Time.fixedDeltaTime;
        transform.position = newPosition;
    }

    void Flap()
    {
        animator.ResetTrigger("flapTrigger");
        animator.SetTrigger("flapTrigger");
        audioController.PlaySFXWing();
        speed = -flapStrength;
        touchControls.CanFlap = false;
    }
    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }

    IEnumerator PlayFallAnimation()
    {
        while(transform.position.y + 2.5f > Mathf.Epsilon)
        {
            ApplyGravity();
            yield return new WaitForEndOfFrame();
        }
        speed = 0;
    }

    IEnumerator PlayVerticalSineMovement()
    {
        Vector2 initialPosition = transform.position;
        while (gameStateController.IsTutorial())
        {
            Vector2 newPosition = transform.position;
            newPosition.y = initialPosition.y + (Mathf.Sin(Time.time * sineSpeed) * sineAmplitude);
            transform.position = newPosition;
            yield return new WaitForEndOfFrame();
        }
    }
}
