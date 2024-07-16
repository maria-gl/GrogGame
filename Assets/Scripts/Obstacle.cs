using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float distance = 1;
    public float deletePos = -5.4f;
    
    public void Move()
    {
        Debug.Log("work");
        float positionY = gameObject.transform.position.y;
        float positionX = gameObject.transform.position.x;
        positionY -= distance;
        gameObject.transform.position = new Vector2(positionX, positionY);

    }

    private void Update()
    {
        if(gameObject.transform.position.y < deletePos)
        {
            Destroy(gameObject);
        }
    }
}
