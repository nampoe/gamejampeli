using UnityEngine;
using UnityEngine.SceneManagement; // Needed for scene loading

public class Health : MonoBehaviour
{
    public float startingHealth = 100f;  
    public float currentHealth;          
    public float damageAmount = 2f;      
    public string deathSceneName = "DeathScreen"; // Set the name of your death screen scene here

    void Start()
    {
        currentHealth = startingHealth;
    }

    void Update()
    {
        // Check if health is zero or below, then load death scene
        if (currentHealth <= 0)
        {
            LoadDeathScreen();
        }
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Player took damage. Current Health: " + currentHealth);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            TakeDamage(damageAmount);
            Destroy(collision.gameObject);
        }
    }

    private void LoadDeathScreen()
    {
        Debug.Log("Player died! Loading death screen...");
        SceneManager.LoadScene(deathSceneName);
    }
}
