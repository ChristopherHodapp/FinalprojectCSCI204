using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part4Controller : MonoBehaviour
{
    private CardController card1;
    private CardController card2;
    private int matches;

    // Update is called once per frame
    void Update()
    {
        if (card1 != null && card2 != null)
        {
            if (card1.tag == card2.tag)
            {
                card1.matched = true;
                card2.matched = true;

                matches++;
                if(matches == 4)
                {
                    PlayerPrefs.DeleteAll();
                    PlayerPrefs.SetString("room1", "solved");
                    PlayerPrefs.Save();
                    SceneControl.NextScene("room2");
                }
                card1 = null;
                card2 = null;

            }
            else
            {
                StartCoroutine(ShowCards());
            }
        }
    }

    public void CheckMatch(CardController card)
    {
        if (card1 == null) {
            card1 = card;
        }
        else
        {
            card2 = card;
        }
    }

    IEnumerator ShowCards()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        yield return new WaitForSeconds(2);

        card1.NotMatched();
        card2.NotMatched();
        card1 = null;
        card2 = null;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
    }
}
