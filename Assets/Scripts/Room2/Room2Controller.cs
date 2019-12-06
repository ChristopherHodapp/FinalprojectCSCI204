using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2Controller : MonoBehaviour
{
    public GameObject rollyWin;
    public GameObject flappyWin;
    public GameObject hurdleWin;
    public GameObject rollyPlay;
    public GameObject flappyPlay;
    public GameObject hurdlePlay;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("rolly") == "won")
        {
            rollyPlay.SetActive(false);
            rollyWin.SetActive(true);
        }
        if (PlayerPrefs.GetString("flappy") == "won")
        {
            flappyPlay.SetActive(false);
            flappyWin.SetActive(true);
        }
        if (PlayerPrefs.GetString("hurdle") == "won")
        {
            hurdlePlay.SetActive(false);
            hurdleWin.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetString("rolly") == "won")
        {
            rollyPlay.SetActive(false);
            rollyWin.SetActive(true);
        }
        if (PlayerPrefs.GetString("flappy") == "won")
        {
            flappyPlay.SetActive(false);
            flappyWin.SetActive(true);
        }
        if (PlayerPrefs.GetString("hurdle") == "won")
        {
            hurdlePlay.SetActive(false);
            hurdleWin.SetActive(true);
        }
    }
}
