using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rigidbodyEnemy;
    public Transform transformTarget;

    public float speed;
    public int damage;
    public int health;

    void Start()
    {
        rigidbodyEnemy = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        transformTarget = player.transform;
    }

    private void FixedUpdate()
    {
        Vector2 direction = (transformTarget.position - transform.position).normalized;
        rigidbodyEnemy.linearVelocity = direction * speed;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
