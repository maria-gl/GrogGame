using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text finalScoreText;
    public int score = 0;
    public GameObject RestartMenu;
    public GameObject TimeBar;
    public GameObject ScoreGroup;

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
}
