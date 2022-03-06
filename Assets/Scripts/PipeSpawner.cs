using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] float frequency = 1f;
    [SerializeField] List<GameObject> pipesList;

    GameStateController gameStateController;

    float elapsedTime = 0f;

    int currentPipeIndex = 0;

    private void Start()
    {
        gameStateController = FindObjectOfType<GameStateController>();    
    }

    void Update()
    {
        if (gameStateController.IsPlaying())
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > frequency)
            {
                elapsedTime = 0;
                Vector2 spawnPoint = transform.position;
                spawnPoint.x = 4;
                spawnPoint.y = Random.RandomRange(-1, 2);
                pipesList[currentPipeIndex].transform.position = spawnPoint;
                currentPipeIndex = (currentPipeIndex + 1) % pipesList.Count;
                //Instantiate(pipesPrefab, spawnPoint, Quaternion.identity, transform);
            }
        }
    }
}
