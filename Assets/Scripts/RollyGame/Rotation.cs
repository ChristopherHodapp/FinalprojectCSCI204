using UnityEngine;

public class Rotation : MonoBehaviour
{
  
    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("pickup"))
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        if (gameObject.CompareTag("rotateX"))
            transform.Rotate(new Vector3(45, 0, 0) * Time.deltaTime);
        if (gameObject.CompareTag("rotateZ"))
            transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
    }
}
