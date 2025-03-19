using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float moveSpeed = 0f;       // Speed at which the enemy moves
    private Transform player;          // Reference to the player's transform

    void Start()
    {
        // Find the player by tag (make sure your player GameObject has the "Player" tag)
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            // Move towards player
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
        }
    }
}
