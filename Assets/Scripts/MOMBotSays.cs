using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOMBotSays : MonoBehaviour
{

    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject canvas3;
    public GameObject canvas4;
    

    public List<GameObject> sayings = new List<GameObject>();

    int pointer;

    void Start()
    {
        sayings.Add(canvas1);
        sayings.Add(canvas2);
        sayings.Add(canvas3);
        sayings.Add(canvas4);
    }
    public void Sayit()
    {
        if (pointer == 0)
        {
            sayings[pointer].SetActive(true);
        }else
        {
            sayings[pointer - 1].SetActive(false);
            if (pointer < 4)
            {
                sayings[pointer].SetActive(true);
            }
        }
        if (pointer > 3)
        {
            pointer = 0;
        }
        else
        {
            pointer++;
        }
    }
}

