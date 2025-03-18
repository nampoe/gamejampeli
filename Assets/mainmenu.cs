using UnityEngine;

public class mainmenu : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Aloitetaan peli"); // small typo fix for aesthetics
        // Add scene loading logic here if needed
        // SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Debug.Log("Suljetaan peli");

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
