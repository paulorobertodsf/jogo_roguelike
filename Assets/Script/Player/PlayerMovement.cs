using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerStats))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;
    private PlayerStats stats;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<PlayerStats>();
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
