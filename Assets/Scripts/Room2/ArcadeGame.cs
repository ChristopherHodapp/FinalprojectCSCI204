using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeGame : ClickableObject
{
    public string gameName;

    void OnMouseDown()
    {
        if (gameName == "solver")
        {
            SceneControl.NextScene(gameName);
        }
        if (gameName != "notYet")
        {
            print("clicked " + gameName);
            SceneControl.NextScene(gameName);
        }
    }
}
