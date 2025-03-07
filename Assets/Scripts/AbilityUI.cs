using UnityEngine;
using UnityEngine.UI;  // For UI elements
using TMPro;  // Optional, if you are using TextMeshPro for cooldowns

public class AbilityUI : MonoBehaviour {
    public Image ability1Icon;  // Ability 1 icon (UI element)
    public Image ability2Icon;  // Ability 2 icon (UI element)
    public Image ability3Icon;  // Ability 3 icon (UI element)
    public Image ability4Icon;  // Ability 4 icon (UI element)
    public Image ability1CooldownFill;  // Fill image for ability 1 cooldown
    public Image ability2CooldownFill;  // Fill image for ability 2 cooldown
    public Image ability3CooldownFill;  // Fill image for ability 3 cooldown
    public Image ability4CooldownFill;  // Fill image for ability 4 cooldown

    public float ability1CooldownTime = 5f;  // Cooldown time for ability 1 (in seconds)
    public float ability2CooldownTime = 5f;  // Cooldown time for ability 2 (in seconds)
    public float ability3CooldownTime = 5f;  // Cooldown time for ability 3 (in seconds)
    public float ability4CooldownTime = 5f;  // Cooldown time for ability 4 (in seconds)

    private float ability1CooldownTimer = 0f;  // Timer to track cooldown for ability 1
    private float ability2CooldownTimer = 0f;  // Timer to track cooldown for ability 2
    private float ability3CooldownTimer = 0f;  // Timer to track cooldown for ability 3
    private float ability4CooldownTimer = 0f;  // Timer to track cooldown for ability 4

    void Update() {
        // Handle ability 1 cooldown
        if (ability1CooldownTimer > 0) {
            ability1CooldownTimer -= Time.deltaTime;  // Decrease timer
            ability1CooldownFill.fillAmount = ability1CooldownTimer / ability1CooldownTime; // Update the fill
        }

        // Handle ability 2 cooldown
        if (ability2CooldownTimer > 0) {
            ability2CooldownTimer -= Time.deltaTime;
            ability2CooldownFill.fillAmount = ability2CooldownTimer / ability2CooldownTime; // Update the fill
        }

        // Handle ability 3 cooldown
        if (ability3CooldownTimer > 0) {
            ability3CooldownTimer -= Time.deltaTime;  // Decrease timer
            ability3CooldownFill.fillAmount = ability3CooldownTimer / ability3CooldownTime; // Update the fill
        }

        // Handle ability 4 cooldown
        if (ability4CooldownTimer > 0) {
            ability4CooldownTimer -= Time.deltaTime;
            ability4CooldownFill.fillAmount = ability4CooldownTimer / ability4CooldownTime; // Update the fill
        }
    }

    public void UseAbility1() {
        // Use ability 1, reset cooldown
        if (ability1CooldownTimer <= 0) {
            Debug.Log("Used Ability 1!");
            ability1CooldownTimer = ability1CooldownTime;  // Start cooldown timer
        }
    }

    public void UseAbility2() {
        // Use ability 2, reset cooldown
        if (ability2CooldownTimer <= 0) {
            Debug.Log("Used Ability 2!");
            ability2CooldownTimer = ability2CooldownTime;  // Start cooldown timer
        }
    }

    public void UseAbility3() {
        // Use ability 3, reset cooldown
        if (ability1CooldownTimer <= 0) {
            Debug.Log("Used Ability 3!");
            ability3CooldownTimer = ability3CooldownTime;  // Start cooldown timer
        }
    }

    public void UseAbility4() {
        // Use ability 4, reset cooldown
        if (ability4CooldownTimer <= 0) {
            Debug.Log("Used Ability 4!");
            ability4CooldownTimer = ability4CooldownTime;  // Start cooldown timer
        }
    }
}
