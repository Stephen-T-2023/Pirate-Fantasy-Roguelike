using UnityEngine;

public class UltimateExplosion : MonoBehaviour {
    public float explosionRadius = 5f;  // Area affected by the explosion
    public int damage = 50;             // Damage dealt to enemies

    void Start() {
        // Add damage to enemies within the radius
        Collider[] enemiesHit = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider enemy in enemiesHit) {
            if (enemy.CompareTag("Enemy")) {
                enemy.GetComponent<EnemyAI>().TakeDamage(damage);
            }
        }

        // Destroy the explosion effect after a short time
        Destroy(gameObject, 0.5f);  // Adjust this to match the length of the particle effect
    }
}
