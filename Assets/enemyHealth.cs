using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int health = 1;  // Default health value, can be set in the Inspector

    void Start()
    {
        // Initialize any values if needed
    }

    void Update()
    {
        // Handle any updates if necessary
    }

    // Call this method when the enemy gets hit by a bullet
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object colliding with the enemy is a bullet
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Decrease health by 1, as the bullet always does 1 damage
            health -= 1;

            // If health reaches 0 or below, destroy the enemy
            if (health <= 0)
            {
                Die();
            }

            // Destroy the bullet after it hits the enemy
            Destroy(collision.gameObject);
        }
    }

    // Destroy the enemy object
    void Die()
    {
        // Add any death effects or animations here (e.g., explosion, particles)
        Destroy(gameObject);  // Destroy the enemy object
    }
}
