using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
    public AbilityUI abilityUI;  // Reference to the AbilityUI script
    public float dashDistance = 5f;  // How far the dash moves
    public float dashCooldown = 5f;  // Cooldown between dashes
    public float dashSpeed = 20f;  // Speed of the dash
    private float lastDashTime = 0f;  // Track last dash time
    private bool isDashing = false;  // Check if player is dashing

    private Vector3 dashDirection;  // Direction of the dash

    public float jumpForce = 10f;  // Jump force
    private bool isGrounded = true;  // Check if player is on the ground

    public void Update() {
        if (Input.GetKeyDown(KeyCode.E) && Time.time - lastDashTime >= dashCooldown && !isDashing) {
            abilityUI.UseAbility3();  // Trigger UI cooldown for ability
            StartCoroutine(Dash());
            lastDashTime = Time.time;  // Reset cooldown timer
        }

        // Jump input (ensure player can still jump while abilities are active)
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            Jump();
        }
    }

    void Jump() {
        if (isGrounded) {
            // Apply upward movement (you can use transform instead of rigidbody for simple jumps)
            transform.Translate(Vector3.up * jumpForce * Time.deltaTime, Space.World);
            isGrounded = false;
        }
    }

    bool IsGrounded() {
        // Simple ground check using a raycast from the player's position downwards
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    IEnumerator Dash() {
        isDashing = true;

        // Determine dash direction (forward direction of the player)
        dashDirection = transform.forward;

        // Perform the dash by moving the player
        float dashTime = 0f;
        Vector3 startPosition = transform.position;

        // Dash movement
        while (dashTime < dashDistance / dashSpeed) {
            dashTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, startPosition + dashDirection * dashDistance, dashTime * dashSpeed);
            yield return null;
        }

        // Ensure the dash ends exactly at the target position
        transform.position = startPosition + dashDirection * dashDistance;

        // Dash cooldown
        yield return new WaitForSeconds(0.2f);  // Dash duration
        isDashing = false;
    }
}
