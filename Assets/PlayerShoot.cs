using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;   // Drag your bullet prefab here
    public Transform firePoint;       // Empty GameObject placed where bullets spawn
    public float bulletSpeed = 30f;
    public float fireRate = 0.1f;     // Time between shots when holding space (in seconds)

    public AudioClip shootSound;      // Sound to play when shooting
    private AudioSource audioSource;  // Reference to audio source

    private bool isShooting = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isShooting)
        {
            StartCoroutine(ShootContinuously());
        }

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
            Shoot();
            yield return new WaitForSeconds(fireRate);
        }
    }

    void Shoot()
    {
        Vector3 spawnPosition = firePoint.position;
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, firePoint.rotation);

        bullet.tag = "Bullet";

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.shooter = this.gameObject;
        }

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.up * bulletSpeed;
        }

        // Play shoot sound
        if (shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }
}
