using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;
    private EnemyStats stats;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<EnemyStats>();
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = direction * stats.moveSpeed;
    }
}