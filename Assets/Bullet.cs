using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnBecameInvisible() { Destroy(gameObject); } // Destroy when off-screen
}
