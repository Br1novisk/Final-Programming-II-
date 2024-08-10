using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abyss : PauseMenu
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponentInParent<PlayerController>())
            Debug.Log("Abismo");
            RestartGame();     
    }
}
