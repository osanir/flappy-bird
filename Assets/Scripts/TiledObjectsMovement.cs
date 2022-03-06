using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiledObjectsMovement : MonoBehaviour
{
    [SerializeField] GameObject backgroundObject;
    [SerializeField] float backgroundSpeed;
    
    [SerializeField] GameObject groundObject;
    [SerializeField] float groundSpeed;

    GameStateController gameStateController;
    private void Start()
    {
        gameStateController = FindObjectOfType<GameStateController>();
    }

    void Update()
    {
        if (!gameStateController.IsGameOver() && !gameStateController.IsPaused())
        {
            MoveTiledObjects();
        }
    }

    void MoveTiledObjects()
    {
        Vector2 newPosition;

        if (backgroundObject.transform.position.x <= -2)
        {
            newPosition = backgroundObject.transform.position;
            newPosition.x += 4.5f;
            backgroundObject.transform.position = newPosition;
        }
        else
        {
            newPosition = backgroundObject.transform.position;
            newPosition.x -= backgroundSpeed * Time.deltaTime;
            backgroundObject.transform.position = newPosition;
        }

        if (groundObject.transform.position.x <= -2)
        {
            newPosition = groundObject.transform.position;
            newPosition.x += 5.25f;
            groundObject.transform.position = newPosition;
        }
        else
        {
            newPosition = groundObject.transform.position;
            newPosition.x -= groundSpeed * Time.deltaTime;
            groundObject.transform.position = newPosition;
        }
    }
}
