using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HurdleGameController : MonoBehaviour
{
    public static HurdleGameController instance;

    public GameObject player1;
    public GameObject coneNotFinishedRight;
    public GameObject coneNotFinishedLeft;
    public GameObject coneFinishedRight;
    public GameObject coneFinishedLeft;
    public GameObject finishLine;
    public Text warningText;
    public Text timerText;
    public GameObject firstHurdle;
    public GameObject playerCPU;
    public Text player1Text;
    public Text playerCPUText;
    public float penalty = 0.5f;
    public int numPlayers = 2;
    public HighScoreScreenController highScore;
    public string newName = "seven";

    public Text speedText;
    private float player1Speed;
    private int count;
    private bool raceStarted;
    private float startTime;
    private bool raceEnded;
    private string unofficialTime;
    private List<string> finishedPlayers = new List<string>();    
    

    // Awake is called before Start
    void Awake()
    {
        // Create Singleton Design Pattern
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (count % 10 == 0 && raceStarted)
        {
            player1Speed = player1.GetComponent<PlayerController>().GetForceInXDirection() / 3.0f;
            speedText.text = player1Speed.ToString("F2") + " m/s";
        }
        count++;
        if (raceStarted && !raceEnded)
        {
            timerText.text = StopWatch();
        }
    }

    public void FinishLine(string playerName, bool isFlying)
    {
        unofficialTime = StopWatch();
        coneNotFinishedLeft.SetActive(false);
        coneNotFinishedRight.SetActive(false);
        coneFinishedLeft.SetActive(true);
        coneFinishedRight.SetActive(true);
        finishLine.SetActive(false);
        raceEnded = true;
        finishedPlayers.Add(playerName);

        if (playerName == "player1")
        {
            player1.GetComponent<PlayerController>().SetTimeAfterPenalty(unofficialTime);
            ShowResults(isFlying);
        }
      
    }

    public void PlayerReady()
    {
        highScore.SetInActive();
        StartCoroutine(CountDown());
    }

    public bool GetRaceStarted()
    {
        return raceStarted;
    }

    public void HitHurdle(string playerName)
    {
        if (playerName != "playerCPU")
        {
            StartCoroutine(WarningTimer(0.5f, "Hurdle Hit!"));
        }
    }

    private IEnumerator CountDown()
    {
        warningText.text = "READY!";
        yield return new WaitForSeconds(1);
        warningText.text = "SET!";
        yield return new WaitForSeconds(1);
        warningText.text = "GO!";
        SoundManager.instance.PlayStarter();
        startTime = Time.time;
        raceStarted = true;
        yield return new WaitForSeconds(2);
        warningText.text = "";
    }

    private string StopWatch()
    {
        float timeElapsed = Time.time - startTime;
        return timeElapsed.ToString("F2");
        
    }
    private IEnumerator WarningTimer(float seconds, string msg)
    {
        warningText.text = msg;
        yield return new WaitForSeconds(seconds);
        warningText.text = "";
    } 

    private void ShowResults(bool didFly)
    {
        if (didFly)
        {
            highScore.SetActive("High Score\n" + newName + "        " + "The Flyer!!");
            highScore.instructionText.text = "Press Enter to EXIT";
        }
        highScore.SetActive();
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Room2");
    }
}
