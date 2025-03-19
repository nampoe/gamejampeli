using UnityEngine;

public class KillTracker : MonoBehaviour
{
    public static int playerKillCount = 0;
    public int killsToActivateBoss = 5;
    public GameObject bossObject; // Drag your boss object here in Inspector

    private bool bossActivated = false;

    void Update()
    {
        if (!bossActivated && playerKillCount >= killsToActivateBoss)
        {
            ActivateBoss();
        }
    }

    private void ActivateBoss()
    {
        bossActivated = true;
        bossObject.SetActive(true); // Enable the boss GameObject
        Debug.Log("Boss Activated!");
    }
}
