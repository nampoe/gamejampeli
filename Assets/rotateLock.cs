using UnityEngine;

public class LockRotationScript : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        if (rb != null)
        {
            rb.freezeRotation = true; // Lock rotation
        }
        else
        {
            Debug.LogError("Rigidbody2D component not found on this object!");
        }
    }
}
