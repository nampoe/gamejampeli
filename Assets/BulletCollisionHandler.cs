using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    // This will be called when the bullet collides with something
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the other object is a bullet (either enemy or player bullet)
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("EnemyBullet"))
        {
            // Destroy both bullets (this bullet and the one it collided with)
            Destroy(gameObject); // Destroy this bullet
            Destroy(collision.gameObject); // Destroy the other bullet
        }
    }
}
