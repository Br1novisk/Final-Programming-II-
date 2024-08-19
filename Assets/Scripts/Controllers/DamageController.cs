using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int damageAmount = 1;


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
            {
                //enemy.TakeDamage(damageAmount);
                DestroyBullet();
                Debug.Log("Enemy takes damage!");
            }
        }

        if (other.CompareTag("Ingredient"))
        {
            IngredientController ingredient = other.GetComponent<IngredientController>();
            
                //ingredient.TakeDamage(damageAmount); 
                DestroyBullet();
                Debug.Log("Ingredient under attack!");
            
        }

        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(damageAmount); // Chame uma função no jogador para causar dano
                Debug.Log("Player took damage!!");
            }
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject); // Destrua a bala
    }
}
