using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Damageable : MonoBehaviour
{
    [SerializeField] float _maxHealth = 100f;
    float _currentHealth;

    [SerializeField] GameObject _hitEffect;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage, Vector3 hitPos, Vector3 hitNormal)
    {
        Instantiate(_hitEffect, hitPos, Quaternion.LookRotation(hitNormal));

        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        print(name + " was destroyed");

        if (CompareTag("Ingredient"))
        {
            FindObjectOfType<IngredientController>().ObjectDestroyed();
        }

        Destroy(gameObject);
    }

 }
