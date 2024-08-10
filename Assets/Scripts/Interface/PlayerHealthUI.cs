using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] PlayerController playerController;
    [SerializeField] float speed;

    float health;
    // Start is called before the first frame update
    public void Start ()
    {
        healthSlider.maxValue = playerController.currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health = playerController.currentHealth;
        healthSlider.value = Mathf.Lerp(healthSlider.value,health, speed * Time.deltaTime);
    }
}
