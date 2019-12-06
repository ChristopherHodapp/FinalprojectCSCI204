using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part1Controller : MonoBehaviour
{
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;

    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Room1Part", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (light1.GetComponent<Light>().color == light2.GetComponent<Light>().color && light3.GetComponent<Light>().color == light1.GetComponent<Light>().color
            && light1.GetComponent<Light>().color == Color.blue)
        {
            PuzzleSolved();
            PlayerPrefs.SetInt("Room1Part", 2);
        }
    }

    void PuzzleSolved()
    {
        wall.SetActive(false);
        light3.GetComponent<Light>().color = Color.yellow;
        light2.GetComponent<Light>().color = Color.yellow;
        light1.GetComponent<Light>().color = Color.yellow;
    }
}
