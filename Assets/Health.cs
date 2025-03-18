using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float startingHealth = 100f;  // Player's starting health
    public float currentHealth;          // Current health after taking damage
    public float damageAmount = 10f;     // Damage amount for each bullet hit

    void Start()
    {
        // Initialize current health
        currentHealth = startingHealth;
    }
private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with an enemy bullet
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            TakeDamage(damageAmount); // Subtract health when hit by enemy bullet
            Destroy(collision.gameObject); // Destroy the enemy bullet after it hits the player
        }
    }

    // Function to handle taking damage
    void TakeDamage(float damage)
    {
        currentHealth -= damage; // Reduce health by damage amount
        Console.Write("otit dmg");

    }
    void Update()
    {
    
    }
    
}
