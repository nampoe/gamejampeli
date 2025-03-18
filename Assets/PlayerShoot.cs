using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Drag your bullet prefab here
    public Transform firePoint;     // Empty GameObject placed where bullets spawn
    public float bulletSpeed = 10f;
    public float fireRate = 0.1f;   // Time between shots when holding space (in seconds)

    private Vector2 lastMoveDirection = Vector2.right; // Default facing right
    private Vector2 moveInput;
    private bool isShooting = false;

    void Update()
    {
        // Capture movement input
        moveInput.x = Input.GetAxisRaw("Horizontal"); // A/D
        moveInput.y = Input.GetAxisRaw("Vertical");   // W/S

        // Update last move direction if the player is moving
        if (moveInput != Vector2.zero)
        {
            lastMoveDirection = moveInput.normalized;
        }

        // Start shooting when spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space) && !isShooting)
        {
            StartCoroutine(ShootContinuously());
        }

        // Stop shooting when spacebar is released
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopCoroutine(ShootContinuously());
            isShooting = false;
        }
    }

    IEnumerator ShootContinuously()
    {
        isShooting = true;

        while (isShooting)
        {
            Shoot(); // Fire a bullet
            yield return new WaitForSeconds(fireRate); // Wait for the specified fire rate
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = lastMoveDirection * bulletSpeed; // Shoots in last movement direction
    }
}
