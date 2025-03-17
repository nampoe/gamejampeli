using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust speed in Inspector
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get Rigidbody2D component
    }

    void Update()
    {
        // Get movement input from WASD keys
        movement.x = Input.GetAxisRaw("Horizontal"); // A (-1) and D (+1)
        movement.y = Input.GetAxisRaw("Vertical");   // W (+1) and S (-1)
    }

    void FixedUpdate()
    {
        // Move the player with physics-based movement
        rb.linearVelocity = movement.normalized * moveSpeed;
    }
}
