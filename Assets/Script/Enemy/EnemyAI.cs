using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyStats))]
public class EnemyAI : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform player;
    private EnemyStats stats;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<EnemyStats>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * stats.moveSpeed;
    }
}
