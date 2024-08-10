using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Points : GameManager
{
    private TMP_Text pointsText;

    private void Start()
    {
        pointsText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdatePointsText (GameManager gameManager)
    {
        pointsText.text = "Points: " + gameManager.ringPoints.ToString() + "/20";
    }
}

