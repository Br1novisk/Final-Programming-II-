using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] private AudioClip doorAudio;


    bool doorOpen = false;

    private float minimum = -54F;
    private float maximum = -46F;
    private static float t = 0.0f;

    private void Update()
    {
        if (doorOpen)
        {
            door.transform.position = new Vector3(Mathf.Lerp(minimum, maximum, t), 0f, -26f);
            t += 0.2f * Time.deltaTime;            
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!doorOpen)
        {
            doorOpen = true;
            SoundFXManager.Instance.PlaySoundFXClip(doorAudio, transform, 0.1f);
            Debug.Log("shhhh");
        }
    }
}
