using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public enum GameState
    {
        TUTORIAL,
        PLAY,
        PAUSE,
        GAMEOVER
    }

    GameState gameState = GameState.TUTORIAL;

    Movement movement;

    void Start()
    {
        movement = FindObjectOfType<Movement>();
    }

    public bool IsPlaying()
    {
        return gameState == GameState.PLAY ? true : false;
    }

    public bool IsPaused()
    {
        return gameState == GameState.PAUSE ? true : false;
    }

    public bool IsGameOver()
    {
        return gameState == GameState.GAMEOVER ? true : false;
    }

    public bool IsTutorial()
    {
        return gameState == GameState.TUTORIAL ? true : false;
    }

    public void SetGameState(GameState newState)
    {
        gameState = newState;
    }

    public GameState GetGameState()
    {
        return gameState;
    }
}
