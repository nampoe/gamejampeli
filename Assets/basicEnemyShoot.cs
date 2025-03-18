using UnityEngine;

public class basicEnemyShoot : MonoBehaviour
{
    public Transform player;               // Reference to the player's transform
    public GameObject enemyBulletPrefab;   // Reference to the enemy's bullet prefab
    public float shootInterval = 1f;       // Time between each shot
    public float rotationSpeed = 5f;       // Speed of rotation towards the player
    public float bulletSpeed = 20f;        // Speed of the bullet (adjust to make the bullet faster)

    private float nextShootTime;           // Time to shoot the next bullet

    void Start()
    {
        nextShootTime = Time.time + shootInterval;  // Initialize next shoot time
    }

    void Update()
    {
        // Rotate the enemy to face the player on the Z-axis
        Vector3 direction = player.position - transform.position;
        direction.z = 0f;  // Only consider X and Y for rotation (Z-axis rotation)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;  // Calculate the angle in degrees
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed * Time.deltaTime);

        // Check if it's time to shoot
        if (Time.time >= nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + shootInterval;  // Reset the next shoot time
        }
    }

    void Shoot()
    {
        // Instantiate the bullet at the enemy's position and facing direction
        GameObject bullet = Instantiate(enemyBulletPrefab, transform.position, transform.rotation);

        // Set the bullet's tag to "EnemyBullet"
        bullet.tag = "EnemyBullet";

        // Get the Bullet script component and assign the shooter (this enemy)
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.shooter = this.gameObject;  // Assign the enemy as the shooter
        }

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); // Assuming it's a 2D Rigidbody for 2D game

        if (rb != null)
        {
            // Shoot the bullet in the direction the enemy is facing (the forward direction of the enemy)
            rb.linearVelocity = transform.up * bulletSpeed;  // Adjust speed as needed
        }
    }
}
