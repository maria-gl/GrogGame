using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text finalScoreText;
    public int score = 0;
    public GameObject RestartMenu;
    public GameObject TimeBar;
    public GameObject ScoreGroup;

    public UnityEvent<bool> gamePaused;
    public UnityEvent<bool> gameUnPaused;

    private void Start()
    {
       
    }

    public void RefreshScore() 
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver() 
    {
        finalScoreText.text = score.ToString();
        TimeBar.SetActive(false);
        RestartMenu.SetActive(true);
        ScoreGroup.SetActive(false);
    }

    public void Pause() 
    {
        Time.timeScale = 0;
        gamePaused.Invoke(true);
    }

    public void UnPause() 
    {
        Time.timeScale = 1;
        gameUnPaused.Invoke(false);
    }
}
