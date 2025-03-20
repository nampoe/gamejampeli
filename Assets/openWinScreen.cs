using UnityEngine;
using UnityEngine.SceneManagement;

public class openWinScreen : MonoBehaviour
{
    public int health = 100;  // Set health in the inspector
    public string sceneToLoad = "WinScreen"; // Name of the main menu scene

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= 1;
            Destroy(collision.gameObject);

            if (health <= 0)
            {
                LoadEndScreen();
            }
        }
    }

    private void LoadEndScreen()
    {
        Debug.Log("Enemy killed! Loading Main Menu...");
        SceneManager.LoadScene(sceneToLoad);
    }
}
