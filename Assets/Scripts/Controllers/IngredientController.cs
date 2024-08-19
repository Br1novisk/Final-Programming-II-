using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IngredientController : MonoBehaviour
{
    private int destroyedObjects = 0;
    [SerializeField] private int targetDestroyedCount = 5;

    [SerializeField] TMP_Text destroyedObjectsText; 

    void Start()
    {
        UpdateDestroyedObjectsText();
    }

    public void ObjectDestroyed()
    {
        destroyedObjects++;
        UpdateDestroyedObjectsText();

        if (destroyedObjects >= targetDestroyedCount)
        {
            Debug.Log("Hottest dog!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
    }

    void UpdateDestroyedObjectsText()
    {
        destroyedObjectsText.text = "Ingredients: " + destroyedObjects + "/" + targetDestroyedCount;
    }
}
