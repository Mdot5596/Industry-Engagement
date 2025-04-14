using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 1;

    private Rigidbody2D rb;
    private Vector2 moveDirection = Vector2.right; // default fallback

    public void SetDirection(Vector2 dir)
    {
        if (dir == Vector2.zero)
        {
            dir = Vector2.right; // Prevent zero vector
        }
        moveDirection = dir.normalized;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = moveDirection * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else if (!other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
