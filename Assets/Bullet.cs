using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject shooter;  // Reference to the shooter (player or enemy)

    void Start()
    {
        if (shooter != null)
        {
            // Ignore collision between the bullet and the shooter
            Collider2D shooterCollider = shooter.GetComponent<Collider2D>();
            if (shooterCollider != null)
            {
                Collider2D bulletCollider = GetComponent<Collider2D>();
                if (bulletCollider != null)
                {
                    Physics2D.IgnoreCollision(bulletCollider, shooterCollider);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // If the bullet collides with another bullet, destroy both
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject); // Destroy the other bullet
            Destroy(gameObject);           // Destroy this bullet
        }

        // Additional logic if you want to handle other collision cases
        // Destroy the bullet if it collides with an enemy or wall
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);  // Destroy the bullet
        }
    }

    void OnBecameInvisible()
    {
        // Destroy the bullet when it goes off-screen
        Destroy(gameObject);
    }
}
