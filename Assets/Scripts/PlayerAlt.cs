using UnityEngine;

public class PlayerAlt : MonoBehaviour {
    public AbilityUI abilityUI;  // Reference to the AbilityUI script
    public GameObject projectilePrefab;
    public float shootCooldown = 1.5f;
    private float lastShootTime = 0f;

    public void Update() {
        if (Input.GetMouseButtonDown(1) && Time.time - lastShootTime >= shootCooldown) {
            abilityUI.UseAbility2();  // Use Ability 2 (Alt)
            ShootProjectile();
            lastShootTime = Time.time;
        }
    }

    public void ShootProjectile() {
        GameObject projectile = Instantiate(projectilePrefab, transform.position + transform.forward, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
    }
}
