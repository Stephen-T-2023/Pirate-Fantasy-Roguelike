using UnityEngine;

public class Projectile : MonoBehaviour {
    public float speed = 10f;  // Speed of the projectile
    public int damage = 10;    // Damage dealt to enemies
    public float lifetime = 1f; // Lifetime before the projectile self-destructs
    public float heightOffset = 1.8f; // Adjust this for the player's head height (e.g., 1.8f)

    private void Start() {
        // Start a timer to destroy the projectile after 'lifetime' seconds
        Destroy(gameObject, lifetime);

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) {
            // Ensure the projectile spawns at the player's head height
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + heightOffset, transform.position.z);

            // Make sure the projectile moves straight from the player's perspective
            transform.position = spawnPosition;  // Adjust the position of the projectile at the correct height

            // Get the forward direction of the player and make the projectile travel in that direction
            Vector3 forwardDirection = transform.forward; // Or use the camera's forward if you want it to shoot based on the camera view

            rb.linearVelocity = forwardDirection * speed; // Move the projectile in a straight line
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            // Deal damage to the enemy
            EnemyAI enemy = collision.gameObject.GetComponent<EnemyAI>();
            if (enemy != null) {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject); // Destroy the projectile on impact
        }
    }
}
