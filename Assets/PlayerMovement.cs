using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Adjust speed in Inspector
    public float rotationSpeed = 100f;  // Rotation speed for counter-clockwise and clockwise rotation
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get Rigidbody2D component
    }

    void Update()
    {
        // Get horizontal and vertical movement input (WASD keys)
        movement.x = Input.GetAxisRaw("Horizontal");  // A (-1) and D (+1)
        movement.y = Input.GetAxisRaw("Vertical");    // W (+1) and S (-1)

        // Rotate counter-clockwise (A key) or clockwise (D key)
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime); // Rotate counter-clockwise
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime); // Rotate clockwise
        }
    }

    void FixedUpdate()
    {
        // Move the player forward or backward based on W/S input, in the direction the sprite is facing
        if (movement.y != 0)
        {
            // Forward or backward movement based on the player's current facing direction (transform.up)
            Vector2 moveDirection = transform.up * movement.y;  // If movement.y is 1 (W), it moves forward in the direction of the sprite's facing
            
            rb.linearVelocity = moveDirection * moveSpeed;  // Apply velocity for movement
        }
        else
        {
            rb.linearVelocity = Vector2.zero;  // Stop the player if no vertical movement is pressed
        }
    }
}
