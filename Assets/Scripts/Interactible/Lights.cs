using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lights : MonoBehaviour
{
    [SerializeField] GameObject houseLight;
    [SerializeField] private AudioClip lightAudio;

    bool houseOn = false;

    private void Update()
    {
        if (houseOn) 
        {
            houseLight.SetActive(true);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!houseOn) 
        {
            houseOn = true;
            houseLight.SetActive(false);

            SoundFXManager.Instance.PlaySoundFXClip(lightAudio, transform, 0.5f);
            Debug.Log("bzzz");
        }

    }
}
