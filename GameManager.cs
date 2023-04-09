using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject PlayButton;
    public GameObject GOText; 
    public GameObject WinImage;
    public float score;


    private void Awake()
    {
        Application.targetFrameRate = 60;
        WinImage.SetActive(false);
        GOText.SetActive(false);
        Pause();
        
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        WinImage.SetActive(false);
        PlayButton.SetActive(false);
        GOText.SetActive(false);

        Time.timeScale = 1f;

        player.enabled = true;

        Obstacles[] ice = FindObjectsOfType<Obstacles>();

        for (int i = 0; i < ice.Length; i++)
        {
            Destroy(ice[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        player.enabled = false;
    }
    public void GameOver()
    {
        GOText.SetActive(true);
        PlayButton.SetActive(true);
        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

        if(score >= 10)
        {
            Win();
        }
    }
    public void Loss()
    {
        score--;
        scoreText.text = score.ToString();
        if (score < 0)
        {
            GameOver();
        }
    }

    public void Win()
    {

        //player.enabled = false;

        Pause();
        GOText.SetActive(false);
        WinImage.SetActive(true);
        PlayButton.SetActive(true);

    }
}
