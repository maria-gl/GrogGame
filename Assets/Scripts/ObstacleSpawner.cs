using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePositions;
    public GameObject obstacle;

    public UnityEvent spawnObstacle;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SpawnObstacle()
    {
        int position = ChoosePosition();
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

    private int ChoosePosition() 
    {
        int n = Random.Range(0, obstaclePositions.Length - 1);
        return n;
    }
}
