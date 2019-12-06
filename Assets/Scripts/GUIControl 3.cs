using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIControl : MonoBehaviour
{
    public Canvas playCanvas;
    public Canvas settingsCanvas;
    public Canvas creditsCanvas;

    public GameObject room2Button;
    public bool testRoom2;
    public bool testSave;

    // Start is called before the first frame update
    void Start()
    {
        playCanvas.enabled = false;
        settingsCanvas.enabled = false;
        creditsCanvas.enabled = false;
        
    }

    void Update()
    {
        if (testSave)
        {
            SaveController.SetRoom1Clear(true);
        }

        if (SaveController.GetRoom1Status() || testRoom2)
        {
            room2Button.GetComponent<Button>().interactable = true;
        }
        else
        {
            room2Button.GetComponent<Button>().interactable = false;
        }
    }


    public void showPlayCanvas()
    {
        playCanvas.enabled = true;
    }

    public void hidePlayCanvas()
    {
        playCanvas.enabled = false;
    }

    public void showSettingsCanvas()
    {
        settingsCanvas.enabled = true;
    }

    public void hideSettingsCanvas()
    {
        settingsCanvas.enabled = false;
    }

    public void showCreditsCanvas()
    {
        creditsCanvas.enabled = true;
    }

    public void hideCreditsCanvas()
    {
        creditsCanvas.enabled = false;
    }

    public void PlayRoom1()
    {
        SceneControl.NextScene("room1");
    }

    public void PlayRoom2()
    {
        SceneControl.NextScene("room2");
    }

    public void ResetProgress()
    {
        SaveController.SetRoom1Clear(false);
    }
}
