using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScreenController : MonoBehaviour
{

    public Text highScoreText;
    public Text instructionText;
    public GameObject highScorePanel;

    private bool active;

    public void SetActive(string scoreText = null)
    {
        if (scoreText != null)
        {
            highScoreText.text = scoreText;
        }
        active = true;
        highScorePanel.SetActive(true);
        highScoreText.GetComponent<Text>().enabled = true;
        instructionText.GetComponent<Text>().enabled = true;
    }

    public void SetInActive()
    {
        active = false;
        highScorePanel.SetActive(false);
        highScoreText.GetComponent<Text>().enabled = false;
        instructionText.GetComponent<Text>().enabled = false;
    }

    public bool Active()
    {
        return active;
    }
}
