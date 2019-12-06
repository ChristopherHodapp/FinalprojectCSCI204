using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part2Controller : MonoBehaviour
{
    public GameObject wall2;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Part2 Trigger"))
        {
            wall2.SetActive(false);
        }
    }
}
