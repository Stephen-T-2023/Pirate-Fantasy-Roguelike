using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;

    public float moveSpeed = 3f;
    public Transform player;
    public float attackRange = 2f;
    public int attackDamage = 10;
    public float attackCooldown = 1.5f;
    private float lastAttackTime;

    private Renderer enemyRenderer;

    void Start()
    {
        currentHealth = maxHealth;
        enemyRenderer = GetComponentInChildren<Renderer>(); // Get renderer for hit flash
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > attackRange)
        {
            MoveTowardPlayer();
        }
        else if (Time.time >= lastAttackTime + attackCooldown)
        {
            AttackPlayer();
        }
    }

    void MoveTowardPlayer()
    {
        transform.LookAt(player); // Face the player
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    void AttackPlayer()
    {
        // lastAttackTime = Time.time;
        // Debug.Log("Enemy attacks!");

        // if (Vector3.Distance(transform.position, player.position) <= attackRange)
        // {
        //     player.GetComponent<PlayerHealth>()?.TakeDamage(attackDamage);
        // }
    }

    // ** TAKES DAMAGE WHEN HIT **
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Enemy hit! HP: {currentHealth}");

        StartCoroutine(HitFlash());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ** FLASH RED WHEN HIT **
    private IEnumerator HitFlash()
    {
        if (enemyRenderer)
        {
            enemyRenderer.material.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            enemyRenderer.material.color = Color.white;
        }
    }

    // ** DIE WHEN HP REACHES 0 **
    void Die()
    {
        Debug.Log("Enemy died!");
        GetComponent<Collider>().enabled = false; // Disable hitbox
        this.enabled = false;
        Destroy(gameObject, 2f); // Destroy after 2 seconds
    }
}
