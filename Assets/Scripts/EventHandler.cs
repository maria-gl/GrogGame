using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EventHandler : MonoBehaviour
{
    public EventHandler eventHandler;
    private TouchControl touchControl;
    public GameObject StartMenu;

    public UnityEvent TapLeft;
    public UnityEvent TapRight;
    public UnityEvent GameOver;

    public bool isGameOver = false;
    public bool isGameStarted = false;
    public bool isGamePaused = false;

    private void Awake()
    {
        eventHandler = this;
        touchControl = new TouchControl();
    }

    private void OnEnable()
    {
        touchControl.Enable();
    }

    private void OnDisable()
    {
        touchControl.Disable();
    }

    private void Start()
    {
        touchControl.Touch.Touch.started += context => Tap();
        StartMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Tap()
    {
        if (!isGameStarted && !isGamePaused)
        {
            isGameStarted = true;
            Time.timeScale = 1;
            StartMenu.SetActive(false);
        }

        if (!isGameOver && isGameStarted && !isGamePaused)
        {
            Vector2 position = Camera.main.ScreenToWorldPoint(touchControl.Touch.TouchPosition.ReadValue<Vector2>());
            if (position.y < 3.75)
            {
                if (position.x <= 0)
                {
                    OnTapLeft();
                }
                else
                {
                    OnTapRight();
                }
            }
        }
    }

    public void OnTapLeft() 
    {
        if (TapLeft != null)
        {
            TapLeft.Invoke();
        }
    }

    public void OnTapRight()
    {
        if (TapRight != null)
        {
            TapRight.Invoke();
        }
    }

    public void OnGameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;

        GameOver.Invoke();
    }

    public void Pause(bool b) 
    {
        Debug.Log(b);
        isGamePaused = b;
    }

    public void Reset()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
