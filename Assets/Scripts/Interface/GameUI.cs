using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //we need to access textmeshpro

public class GameUI : MonoBehaviour
{

    [SerializeField] 
    TMP_Text scoreText, timeText;

    float timeElapsed = 0f;
    bool gamePaused = false;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("F"))
        {
            gamePaused = !gamePaused;
        }

        if(gamePaused)
        {
            Time.timeScale = gamePaused ? 0.0f : 1f;
        }
    }

    private void FixedUpdate()
    {
        //we use FixedUpdate to update the time;
        timeElapsed += Time.fixedDeltaTime;
        UpdateText();
    }

    private void UpdateText()
    {
        //where we update our score and time Texts;
        timeText.text = string.Format("Time: {0:0.00}", timeElapsed);
    }
}
