using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public Image timeLeft;
    public float timeVariable = 60f;
    public float maxTime; 
    public UnityEvent TimeRunOut;

    private bool invokedOnce = false;

    void Start()
    {
        maxTime = timeVariable;
    }

    void Update()
    {
        if (timeVariable > 0)
        {
            SubtractTime(Time.deltaTime);
        }
        else
        {
            if (!invokedOnce)
            {
                TimeRunOut.Invoke();
                invokedOnce = true;
            }
        }
    }

    public void SubtractTime(float time) 
    {
        timeVariable -= time;
        timeLeft.fillAmount = timeVariable / maxTime;
    }

    public void AddTime(float time) 
    {
        timeVariable += time;
        timeVariable = Mathf.Clamp(timeVariable, 0, 60f);

        timeLeft.fillAmount = timeVariable / 60f;
    }
}
