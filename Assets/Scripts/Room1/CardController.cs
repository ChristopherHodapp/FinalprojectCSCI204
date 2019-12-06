using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public bool matched;
    public GameObject controller;
    private bool showing;

    void OnMouseDown()
    {
        if (!matched)
        {
            transform.Rotate(0.0f, 0.0f, 180.0f, Space.Self);
            controller.GetComponent<Part4Controller>().CheckMatch(this);
        }
    }

    public void NotMatched()
    {
        if (!matched)
        {
            transform.Rotate(0.0f, 0.0f, 180.0f, Space.Self);
        }
        
    }
}
