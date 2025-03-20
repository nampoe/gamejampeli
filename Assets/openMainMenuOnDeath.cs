using UnityEngine;
using UnityEngine.SceneManagement;

public class openMainMenuOnEnemyDeath : MonoBehaviour
{
    public int health = 1;  // Set health in the inspector
    public string sceneToLoad = "MainMenu"; // Name of the main menu scene

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= 1;
            Destroy(collision.gameObject);

            if (health <= 0)
            {
                LoadMainMenu();
            }
        }
    }

    private void LoadMainMenu()
    {
        Debug.Log("Enemy killed! Loading Main Menu...");
        SceneManager.LoadScene(sceneToLoad);
    }
}
