using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class momBot : MonoBehaviour
{
    public GameObject sayit;

    void OnMouseDown()
    {
        sayit.GetComponent<MOMBotSays>().Sayit();
    }

}
