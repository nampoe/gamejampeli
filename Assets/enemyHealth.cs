using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int health = 1;  // Set health in the Inspector

    public delegate void EnemyDeathHandler(GameObject enemy);
    public static event EnemyDeathHandler OnEnemyDeath;

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        // Check if the colliding object is a bullet
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= 1;

            if (health == 0)
            {
                Kill();  // Call Kill instead of Die
            }

            Destroy(collision.gameObject);
        }
    }

    private bool isDead = false;

    public void Kill()
    {
        if (isDead) return;  // Prevent double kill
        isDead = true;
        KillTracker.playerKillCount++;
        Debug.Log("Kill! Total kills: " + KillTracker.playerKillCount);
        OnEnemyDeath?.Invoke(gameObject);
        Destroy(gameObject);
    }

}
