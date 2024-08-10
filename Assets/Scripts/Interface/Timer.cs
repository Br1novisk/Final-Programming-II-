using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] float currentTime;
    private float startTime = 1;


    void Start()
    {
        currentTime = startTime;
    }

    void Update()
    {
        if (currentTime > 0) 
        {
            currentTime += Time.deltaTime;
        }

        string timeString = FormatTime(currentTime);

        timerText.text = "Timer: " + timeString;
    }

    string FormatTime(float time)
    {
        int seconds = Mathf.FloorToInt(time);
        return seconds.ToString();
    }
}

