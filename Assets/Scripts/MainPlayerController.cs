using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerController : MonoBehaviour
{
    
    public float speed;
    public float rotationSpeed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical * speed);
        Vector3 eulerAngleVelocity = new Vector3(0, moveHorizontal * rotationSpeed, 0);

        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
        rb.AddRelativeForce(movement);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
