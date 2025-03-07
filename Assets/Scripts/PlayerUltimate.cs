using UnityEngine;

public class PlayerUltimate : MonoBehaviour {
    public AbilityUI abilityUI;  // Reference to the AbilityUI script
    public GameObject bigExplosionPrefab;  // Prefab for the explosion effect
    public float cooldownTime = 10f;       // Cooldown time for the ultimate ability
    private float lastUsedTime = 0f;

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Q) && Time.time - lastUsedTime >= cooldownTime) {
            abilityUI.UseAbility4();  // Use Ability 4 (Ult)
            UseUltimate();
            lastUsedTime = Time.time;
        }
    }

    public void UseUltimate() {
        // Instantiate the explosion at the player's position, in front of the player
        Vector3 spawnPosition = transform.position + transform.forward * 5f;  // 5 units in front of the player

        // Instantiate the explosion effect prefab at the spawn position
        Instantiate(bigExplosionPrefab, spawnPosition, Quaternion.identity);
    }
}
