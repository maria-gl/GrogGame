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
    public UnityEvent TapLeft;
    public UnityEvent TapRight;
    public bool isGameOver = false;
    public UnityEvent GameOver;

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
    }

    public void Tap()
    {
        if (!isGameOver)
        {
            Vector2 position = Camera.main.ScreenToWorldPoint(touchControl.Touch.TouchPosition.ReadValue<Vector2>());
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

    public void Reset()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
