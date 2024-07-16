using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class EventHandler : MonoBehaviour
{
    public EventHandler eventHandler;
    private TouchControl touchControl;
    public UnityEvent TapLeft;
    public UnityEvent TapRight;
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
        Vector2 position = Camera.main.ScreenToWorldPoint(touchControl.Touch.TouchPosition.ReadValue<Vector2>());
        if(position.x <= 0)
        {
            OnTapLeft();
        }
        else 
        {
            OnTapRight();
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
}
