using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RollABallController : MonoBehaviour
{

    public HighScoreScreenController highScore;

    public string newName = "five";


    private bool isEnterPressed;
    private bool isGameOver;

    private string maxPoints = "13";

    void Start()
    {
        highScore.SetActive();
        PlayerPrefs.DeleteAll();
    }


    // Update is called once per frame
    void Update()
    {
        isEnterPressed = Input.GetKeyDown("return");
        if (isEnterPressed && highScore.Active() == true)
        {
            highScore.SetInActive();

			if (isGameOver)
            {
                SceneManager.LoadScene("Room2");
            }


        }
    }

    public void SetGameOver(bool newHighScore)
    {
        isGameOver = true;

        if (newHighScore)
        {
            highScore.SetActive("High Score\n" + newName + "        " + maxPoints + " points");
            PlayerPrefs.SetString("rolly", "won");
        }

        highScore.SetActive();
    }
}
