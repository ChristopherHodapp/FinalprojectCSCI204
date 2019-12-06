using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeGame : ClickableObject
{
    public string gameName;

    void OnMouseDown()
    {
        print("clicked " + gameName);
        SceneControl.NextScene(gameName);
    }
}
