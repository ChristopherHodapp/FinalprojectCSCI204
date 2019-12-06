using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlappyGameControl : MonoBehaviour
{
    public static FlappyGameControl instance;
    public bool gameOver = true;
    public float scrollSpeed = -1.5f;
    public ColumnPool pool;
    public int initialDifficulty;
    public Coin coin;
    public HighScoreScreenController highScore;
    public int currentHighScore = 5;
    public string newName = "two";
    public Text scoreText;
    public Text coinScoreText;
    
    private int difficulty;
    private int score;
    private int coinScore;
    private bool won;
    private bool restart = true;
    private bool isEnterPressed;




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
    void Start()
    {
        difficulty = initialDifficulty;
    }
    // Update is called once per frame
    void Update()
    {
        isEnterPressed = Input.GetKeyDown("return");
        if (gameOver == true && Input.GetMouseButton(0) && !won)
        {
            highScore.SetActive();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
        if (restart)
        {
            highScore.SetInActive();
        }
        if ( isEnterPressed)
        {
            SceneManager.LoadScene("Room2");
        }
    }

    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }

        score++;
        scoreText.text = "Score: " + score.ToString();

        if ((score % 5) == 0)
        {

            difficulty++;
            pool.setSpawnRate(difficulty);
        }
    }

    public void BirdCoinScored()
    {
        if (gameOver)
        {
            return;
        }

        coinScore += 10;
        coinScoreText.text = "Coins: " + coinScore.ToString();
    }
    public void BirdDied()
    {
        restart = false;
        scrollSpeed = 0.0f;

        if ((score + coinScore) > currentHighScore)
        {
            won = true;
            highScore.SetActive("High Score\n" + newName + "        " + (score + coinScore) + " points");
            PlayerPrefs.SetString("flappy", "won");
        }
        else
        {
            highScore.SetActive();
        }
        gameOver = true;

    }
}
