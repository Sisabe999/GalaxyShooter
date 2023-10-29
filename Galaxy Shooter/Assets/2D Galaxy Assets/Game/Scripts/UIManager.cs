using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Sprite[] lives;
    public Image livesImageDisplay;
    public Text scoreText;
    public int score = 0;

    public GameObject titleScreen;

    public void UpdateLives(int currentLives)
    {
        Debug.Log("Player lifes: " + currentLives);
        livesImageDisplay.sprite = lives[currentLives]; 
    }

    public void UpdateScore()
    {
        score += 10;

        scoreText.text = "Score: " + score;
    }

    public void ShowScreen()
    {
        titleScreen.SetActive(true);
    }

    public void HideScreen()
    {
        titleScreen.SetActive(false);
        score = 0;
        scoreText.text = "Score: ";
    }
}
