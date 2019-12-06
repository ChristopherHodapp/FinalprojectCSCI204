using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager: MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource introAudio;
    public AudioSource starter;

    void Awake()
    {
        // Create Singleton Design Pattern
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
   
            introAudio.time = 15.0f;
            introAudio.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
            if (introAudio.time > 25f)
            {
                introAudio.volume = 0.3f;
            }
    }

    public void PlayStarter()
    {
        starter.Play();
    }
}
