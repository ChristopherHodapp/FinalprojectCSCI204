using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIControl : MonoBehaviour
{
    public Canvas playCanvas;
    public Canvas settingsCanvas;
    public Canvas creditsCanvas;

    // Start is called before the first frame update
    void Start()
    {
        playCanvas.enabled = false;
        settingsCanvas.enabled = false;
        creditsCanvas.enabled = false;
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
}
