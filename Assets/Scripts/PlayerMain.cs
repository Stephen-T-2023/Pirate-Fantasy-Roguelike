using UnityEngine;

public class PlayerMain : MonoBehaviour {
    public AbilityUI abilityUI;  // Reference to the AbilityUI script
    public float attackCooldown = 1.0f; // Time between attacks
    private float lastAttackTime = 0f;

    public void Update() {
        if (Input.GetMouseButtonDown(0) && Time.time - lastAttackTime >= attackCooldown) {
            abilityUI.UseAbility1();  // Use Ability 1 (Main)
            // Call attack function
            MeleeAttack();
            lastAttackTime = Time.time;
        }
    }

    public void MeleeAttack() {
        // Logic for dealing damage to nearby enemies
        Collider[] enemiesHit = Physics.OverlapSphere(transform.position, 1f); // Hit within a radius
        foreach (Collider enemy in enemiesHit) {
            if (enemy.CompareTag("Enemy")) {
                // Deal damage to enemy
                enemy.GetComponent<EnemyAI>().TakeDamage(10);
            }
        }
    }
}
