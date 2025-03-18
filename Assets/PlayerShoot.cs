using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;   // Drag your bullet prefab here
    public Transform firePoint;       // Empty GameObject placed where bullets spawn
    public float bulletSpeed = 30f;
    public float fireRate = 0.1f;     // Time between shots when holding space (in seconds)

    private bool isShooting = false;

    void Update()
    {
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
        // Ensure firePoint is positioned correctly, if it's a child of the player
        Vector3 spawnPosition = firePoint.position;

        // Instantiate the bullet at the fire point with the sprite's current rotation
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, firePoint.rotation);

        // Set the bullet's tag to "Bullet"
        bullet.tag = "Bullet";

        // Get the Bullet script component and assign the shooter (the player)
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.shooter = this.gameObject;  // Assign the player as the shooter
        }

        // Get the Rigidbody2D component of the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // Set the bullet's velocity to the direction the sprite is facing (firePoint.up)
            rb.linearVelocity = firePoint.up * bulletSpeed;
        }
    }
}
