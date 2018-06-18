using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public bool isGameStart;
    int score, highScore;
    public Text hiScore, CurScore;
    void Start()
    {
        isGameStart = false;
        score = 0;
        highScore = PlayerPrefs.GetInt("highscore");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameStart();
        }

        //if (Input.GetTouch(0).phase==TouchPhase.Stationary)
        //{
        //    GameStart();
        //}

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highscore", highScore);
        }

        hiScore.text = highScore.ToString();
        


    }

    private void GameStart()
    {
        isGameStart = true;
        FindObjectOfType<WallMaker>().WallCreater();
        //Wallmaker içerisindeki fonksiyonu çağırdım 
    }

    internal void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void MakeScore()
    {
        
        score++;
        CurScore.text = score.ToString();
    }
}
