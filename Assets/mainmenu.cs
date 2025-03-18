using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Aloitetaan peli"); 
        SceneManager.LoadScene("Level1");
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
