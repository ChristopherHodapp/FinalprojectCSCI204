using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController: MonoBehaviour
{ 
    public static void SetRoom1Clear(bool status)
    {
        if (status)
        {
            PlayerPrefs.SetString("room1", "clear");
        }
        else
        {
            PlayerPrefs.DeleteKey("room1");
        }
    }

    public static bool GetRoom1Status()
    {
        return PlayerPrefs.HasKey("room1");
    }


}
