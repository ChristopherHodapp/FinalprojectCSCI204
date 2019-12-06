using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string playerName = "player1";

    //Forces
    public float baseForceInXDirection = 30.0f;
    public float jumpForce = 500.0f;
    public float forceInXDirectionMultiplier = 1.0f;
    public float maxSpeed = 15.0f;

    private Vector3 movement;
    private float forceInXDirection;

    //Components
    private Animator anim;
    private Rigidbody rb;

    //Flags
    private bool finishTriggerHit;
    private bool isJumpPressed;
    private bool isRunPressed;
    private bool raceStarted;
    private bool isFlying;

    //Stats
    private int hurdlesHit;
    private string timeAfterPenalty;
    private string timeBeforePenalty;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forceInXDirection = baseForceInXDirection;
        anim = GetComponent<Animator>();


    }

    // Update is called once per frame

    private void Update()
    {
        
        if (playerName != "playerCPU")
        {
            isJumpPressed = Input.GetKeyDown("space");
            isRunPressed = Input.GetKeyDown("w");
            if (Input.GetKeyDown("return") && !raceStarted)
            {

                HurdleGameController.instance.PlayerReady();
                
            }
            if (Input.GetKeyDown("return") && raceStarted)
            {
                HurdleGameController.instance.EndGame();
            }
        }
        if (!raceStarted)
        {
            raceStarted = HurdleGameController.instance.GetRaceStarted();
            if (raceStarted) {
                print("Race Started");
                anim.SetTrigger("Start"); }
        }
    }
    void FixedUpdate()
    {
        if (playerName != "playerCPU"){PlayerMovement();}
        else { AIMovement(); }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Flying"))
        {
            isFlying = true;
            Vector3 finishLine = new Vector3(95.0f, 0.5f, 0.0f);
            transform.position = finishLine;
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            
            anim.SetTrigger(gameObject.tag);
            finishTriggerHit = true;
            HurdleGameController.instance.FinishLine(playerName, isFlying);
        }
        if (other.gameObject.CompareTag("Hurdle"))
        {
            print("Hurdle Hit");
            HurdleGameController.instance.HitHurdle(playerName);
            hurdlesHit++;
        }
        if (playerName == "playerCPU")
        {
            if (other.gameObject.CompareTag("JumpTrigger"))
            {
                print("Jump Trigger Hit");
                anim.SetTrigger("Jump");
                rb.AddForce(forceInXDirection, 550.0f, 0.0f);
            }
        }
    }
    public float GetForceInXDirection()
    {
        return forceInXDirection;
    }

    public int GetHurdlesHit()
    {
        return hurdlesHit;
    }

    public void SetTimeAfterPenalty(string loggedTime)
    {
        timeBeforePenalty = loggedTime;
        float temp = float.Parse(loggedTime) + (hurdlesHit * HurdleGameController.instance.penalty);
        timeAfterPenalty = temp.ToString("F2");
    }

    public string GetTimeAfterPenalty()
    {
        return timeAfterPenalty;
    }

    public string GetTimeBeforePenalty()
    {
        return timeBeforePenalty;
    }

    private void PlayerMovement()
    {
        if (!finishTriggerHit && raceStarted)
        {
            
            if (isJumpPressed)
            {
                anim.SetTrigger("Jump");
                rb.AddForce(Vector3.up * jumpForce);
                
            }
            else
            {
                movement = new Vector3(forceInXDirection, 0.1f, 0.0f);
            }
            if (isRunPressed && !isJumpPressed)
            {
                if (forceInXDirection < (maxSpeed - 4.0f))
                {
                    forceInXDirection += (4.0f * forceInXDirectionMultiplier);
                }
                else
                {
                    forceInXDirection = (maxSpeed * forceInXDirectionMultiplier);
                }

            }
            else
            {
                // TODO: Disallow jumping while in air
                if (isJumpPressed)
                {
                    
                }
                else
                {
                    if (forceInXDirection > baseForceInXDirection*forceInXDirectionMultiplier)
                    {
                        forceInXDirection -= (0.2f * forceInXDirectionMultiplier);
                    }
                    else { forceInXDirection = baseForceInXDirection* forceInXDirectionMultiplier; }
                }

            }
            rb.AddForce(movement);
        }
    }

    private void AIMovement()
    {
        if (!finishTriggerHit && raceStarted)
        {

            movement = new Vector3(forceInXDirection, 0.0f, 0.0f);

            if (forceInXDirection < 35.0f)
            {
                forceInXDirection += 5.0f;
            }
            rb.AddForce(movement);
        }
    }
}
