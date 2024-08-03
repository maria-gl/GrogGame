using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

    public float distance = 1;
    public float losePosition = -5;
    public float leftBorder = -3;
    public float rigthBorder = 3f;

    public UnityEvent gameOver;
    public UnityEvent gameStart;
    public bool isGameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        gameStart.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y <= losePosition && !isGameOver)
        {
            isGameOver = true; 
            gameOver.Invoke();
        }
    }

    public void MoveRight()
    {
        float positionY = gameObject.transform.position.y + 0.01f;
        float positionX = gameObject.transform.position.x;
        positionX += distance;
        if ((positionX < rigthBorder && positionX > leftBorder) && !isGameOver)
        {
            gameObject.transform.position = new Vector2(positionX, positionY);
        }
    }

    public void MoveLeft() 
    {
        float positionY = gameObject.transform.position.y + 0.01f;
        float positionX = gameObject.transform.position.x;
        positionX -= distance;
        if ((positionX < rigthBorder && positionX > leftBorder) && !isGameOver)
        {
            gameObject.transform.position = new Vector2(positionX, positionY);
        }
    }
}
