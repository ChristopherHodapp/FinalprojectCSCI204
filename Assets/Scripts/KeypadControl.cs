using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadControl : MonoBehaviour
{
    public Canvas KeypadCanvas;

    // Start is called before the first frame update
    void Start()
    {
        KeypadCanvas.enabled = false;

    }

        public void showKeypadCanvas()
        {
            KeypadCanvas.enabled = true;
        }
        public void hideKeypadCanvas()
        {
            KeypadCanvas.enabled = false;
        }
    
}
