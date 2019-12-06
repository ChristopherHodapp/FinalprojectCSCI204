using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUController : MonoBehaviour
{
    public float baseSpeed = 0.0f;
    public float jumpForce = 400.0f;
    public string playerName;

    private bool finished;
    private Vector3 movement;
    private bool isJumpPressed;
    private bool isRunPressed;
    private bool raceStarted;
    private int hurdlesHit;
    private string finalTime;
    private float sphereRadius = 0.5f;
    private float speed;
    private string unofficialTime;
    private Animator anim;




    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = baseSpeed;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    private void Update()
    { 
        if (!raceStarted)
        {
            raceStarted = HurdleGameController.instance.GetRaceStarted();
            if (raceStarted)
            {
                anim.SetTrigger("Start");
            }
        }
    }
    void FixedUpdate()
    {
        AIMovement();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            finished = true;
            HurdleGameController.instance.FinishLine(playerName, false);
            anim.SetTrigger("FinishRace");
        }
        if (other.gameObject.CompareTag("Hurdle"))
        {
            HurdleGameController.instance.HitHurdle(playerName);
            hurdlesHit++;
        }

        if (other.gameObject.CompareTag("JumpTrigger"))
        {
            anim.SetTrigger("Jump");
            rb.AddForce(speed, 550.0f, 0.0f);
        }    
        
    }
    public float GetSpeed()
    {
        return speed;
    }

    public int GetHurdlesHit()
    {
        return hurdlesHit;
    }

    public void SetFinalTime(string loggedTime)
    {
        unofficialTime = loggedTime;
        float temp = float.Parse(loggedTime) + (hurdlesHit * HurdleGameController.instance.penalty);
        finalTime = temp.ToString("F2");
    }

    public string GetFinalTime()
    {
        return finalTime;
    }

    public string GetUnofficialTime()
    {
        return unofficialTime;
    }

    

    private void AIMovement()
    {
        if (!finished && raceStarted)
        {
            movement = new Vector3(speed, 0.0f, 0.0f);

            if (speed < 35.0f)
            {
                speed += 5.0f;
            }
            rb.AddForce(movement);
        }
    }
}
