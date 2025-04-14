using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float detectionRange = 5f;
    public int health = 3;

    [Header("Shooting")]
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootCooldown = 2f;
    private float shootTimer;

    private Transform player;
    private Rigidbody2D rb;
    public RoomManager roomManager;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        shootTimer = shootCooldown;
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange)
        {
            // Move toward player
            Vector2 direction = (player.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);

            // Shooting logic
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0f)
            {
                ShootAtPlayer();
                shootTimer = shootCooldown;
            }
        }
    }

    void ShootAtPlayer()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            // Calculate direction to player from firePoint in world space
            Vector2 direction = (player.position - firePoint.position).normalized;

            if (direction == Vector2.zero)
                direction = Vector2.right; // fallback

            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            Projectile projScript = projectile.GetComponent<Projectile>();

            if (projScript != null)
            {
                projScript.SetDirection(direction);
            }

            // Debug draw line
            Debug.DrawRay(firePoint.position, direction * 2f, Color.red, 1f);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            if (roomManager != null)
            {
                roomManager.EnemyDefeated();
            }

            Destroy(gameObject);
        }
    }
}
