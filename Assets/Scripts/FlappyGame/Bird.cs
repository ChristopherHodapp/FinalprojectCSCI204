using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce = 200f;

    private bool isDead;
    private Rigidbody2D rb2d;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (FlappyGameControl.instance.gameOver)
        {
            isDead = true;
        }
        if (isDead == false)
        {
            if (Input.GetMouseButtonDown (0))
            {
                // after every jump reset velocity to zero so that each player action
                //has the same effect
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger ("Flap");
            }
        }
    }

    void OnCollisionEnter2D()
    { 
         rb2d.velocity = Vector2.zero;
         isDead = true;
         anim.SetTrigger("Die");
         FlappyGameControl.instance.BirdDied();   
        
    }
}
