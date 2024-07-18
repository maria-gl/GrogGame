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
    

    void Start()
    {
        maxTime = timeVariable;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (timeVariable > 0)
        {
            SubtractTime(Time.deltaTime);
        }
        else
        {
            TimeRunOut.Invoke();
        }
    }

    void SubtractTime(float time) 
    {
        timeVariable -= time;
        timeLeft.fillAmount = timeVariable / maxTime;
    }

    void AddTime(float time) 
    {
        timeVariable += time;
        timeVariable = Mathf.Clamp(timeVariable, 0, 60f);

        timeLeft.fillAmount = timeVariable / 60f;
    }
}
