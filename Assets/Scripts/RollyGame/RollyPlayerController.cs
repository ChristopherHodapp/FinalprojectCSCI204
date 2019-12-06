using UnityEngine;
using UnityEngine.UI;

public class RollyPlayerController : MonoBehaviour
{
    public RollABallController gameController;

    public float speed;
    public Text countText;
    public Text winText;
    public int pickupCount;
    private Rigidbody rb;
    private int count;
    private bool allowMovement = true;



    private void Start()
    {
        count = 0;
        pickupCount = 12;
        rb = GetComponent<Rigidbody>();
        SetCountText();
        winText.text = "";
    }

    private void FixedUpdate()
    {
        float moveHoizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (allowMovement)
        {
            Vector3 movement = new Vector3(moveHoizontal, 0.0f, moveVertical);
            rb.AddForce(movement * speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();

        }
        if (other.gameObject.CompareTag("out of bounds"))
        {
            SetWinText(false);
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if (count >= 12)
        {
            SetWinText(true);
        }
    }

    void SetWinText(bool state)
    {
        AllowMovement(false);

        if ((gameController != null) && !state)
        {
            int score = pickupCount - count + 1;
            winText.text = "You Earned " + score.ToString() + " Extra Credit Points!";
            gameController.SetGameOver(true);
        }
        else
        {
            winText.text = "Game Over";
            gameController.SetGameOver(false);
        }
    }

    public void AllowMovement(bool state)
    {
        allowMovement = state;
    }
}
