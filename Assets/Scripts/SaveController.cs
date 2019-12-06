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

    public static void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public static int GetInt(string key)
    {
        return PlayerPrefs.GetInt(key);
    }

    public static void SetString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }

    public static string GetString(string key)
    {
        return PlayerPrefs.GetString(key);
    }




}
