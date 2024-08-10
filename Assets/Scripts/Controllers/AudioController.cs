using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : PauseMenu
{
    public AudioSource audioSource;

    public void Awake()
    {
        audioSource.Play();
    }

    void FixedUpdate()
    {
        if (!isPaused)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }
    }
}