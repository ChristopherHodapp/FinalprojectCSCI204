using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOMBotSays : MonoBehaviour
{

    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject canvas3;
    public GameObject canvas4;

    public GameObject[] colorList = new GameObject[4];

    int pointer;

    void Start()
    {
        //colorList = new GameObject{ canvas1, canvas2, canvas3, canvas4 };
    }
    void OnMouseDown()
    {
        if (pointer == 0)
        {
            colorList[pointer].SetActive(true);
        }else
        {
            colorList[pointer - 1].SetActive(false);
            colorList[pointer].SetActive(true);
        }
        if (pointer == 2)
        {
            pointer = 0;
        }
        else
        {
            pointer++;
        }
    }
}

