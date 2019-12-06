using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : ClickableObject
{
    Light lt;
    readonly Color[] colorList = { Color.red, Color.blue, Color.green };
    int pointer;

    void Start()
    {
        lt = GetComponent<Light>();
    }
    void OnMouseDown()
    {
        print("lamp clicked");
        lt.color = colorList[pointer];

        if (pointer == 2)
        {
            pointer = 0;
        }else
        {
            pointer++;
        }
    }
}
