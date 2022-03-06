using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] float pipeSpeed = 5f;
    GameStateController gameStateController;

    private void Start()
    {
        gameStateController = FindObjectOfType<GameStateController>();
    }

    void Update()
    {
        if (gameStateController.IsPlaying())
        {
            MovePipes();
        }
    }

    void MovePipes()
    {
        transform.position = transform.position + (Vector3.left * pipeSpeed * Time.deltaTime);
    }
}
