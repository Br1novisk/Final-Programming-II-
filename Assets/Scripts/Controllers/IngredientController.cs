using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientController : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float objective;

    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        objective = 5f;

    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Ingredient Integrity: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Ingredient Collected");
        objective--;
        Destroy(gameObject);

    }
}
