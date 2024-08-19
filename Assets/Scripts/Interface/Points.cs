using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    [SerializeField] private TMP_Text pointsText;
    [SerializeField] private GameManager gameManager;  

    private void Start()
    {
        if (pointsText == null)
        {
            pointsText = GetComponent<TMP_Text>();
        }

        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }

        UpdatePointsText(); 
    }

    public void UpdatePointsText()
    {
        if (pointsText != null && gameManager != null)
        {
            pointsText.text = "Points: " + gameManager.ringPoints.ToString() + "/20";
        }
        else
        {
            Debug.LogError("PointsText ou GameManager não está atribuído!");
        }
    }
}
