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
    
    // Update is called once per frame
    void Update()
    {
        if (light1.GetComponent<Light>().color == light2.GetComponent<Light>().color && light3.GetComponent<Light>().color == light1.GetComponent<Light>().color
            && light1.GetComponent<Light>().color == Color.blue)
        {
            wall.SetActive(false);
            light3.GetComponent<Light>().color = Color.yellow;
            light2.GetComponent<Light>().color = Color.yellow;
            light1.GetComponent<Light>().color = Color.yellow;
        }
    }
}
