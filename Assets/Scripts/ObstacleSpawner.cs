using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePositions;
    public GameObject obstacle;
    public GameObject bonus;
    public UnityEvent spawnObstacle;
    public int startPosition = 2;
    public int previousPosition;
    public int lilipadsQuantity = 9;
    public bool isGameOver = false;

    public int maxFrequency = 10;

    private Transform bonusTransform;

    void Start()
    {
        SpawnObstacle(startPosition);
        previousPosition = startPosition;

        for (int i = 0; i < lilipadsQuantity; i++) 
        {
            SpawnObstacleAtPosition();
        }
    }

    void Update()
    {
        
    }

    public void SpawnObstacleAtPosition() 
    {
        if (!isGameOver)
        {
            int position = ChoosePosition(previousPosition);
            SpawnObstacle(position);
            SpawnBonus(position);
            previousPosition = position;
        }
    }

    public void SpawnObstacle(int position)
    {
        Instantiate(obstacle, obstaclePositions[position].transform.position, Quaternion.identity);

        // change it so only last created object is added
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject gameObject in gameObjects) 
        {
            spawnObstacle.AddListener(gameObject.GetComponent<Obstacle>().Move);
        }
        
        spawnObstacle.Invoke();
        spawnObstacle.RemoveAllListeners();

        /* solution with adding all objects as listeners and then removing them all is bad 
         * but i couldnt make a better solution work ;--; */
    }

    private int ChoosePosition(int position = 0) 
    {
        int n = UnityEngine.Random.Range(-5, 5);
        if(n <= 0) 
        {
            if(position - 1 >= 0) 
            {
                position -= 1;
            }
            else
            {
                position += 1;
            }
        }
        else
        {
            if (position + 1 < obstaclePositions.Length)
            {
                position += 1;
            }
            else
            {
                position -= 1;
            }
        }
        return position;
    }

    public void SpawnBonus(int position)
    {
        bool spawnBonus = false;
        int frequency = UnityEngine.Random.Range(0, 100);
        if (frequency <= maxFrequency)
        {
            spawnBonus = true;
        }       

        if (spawnBonus) 
        {
            Instantiate(bonus, obstaclePositions[position].transform.position + new Vector3(0, 0.01f), Quaternion.identity);
        }
    }

    public void OnGameOver() 
    {
        isGameOver = true;
    }
}
