using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private Rigidbody2D rigidbodyEnemy;
    private Transform transformTarget;

    [HideInInspector]
    public EnemyModel enemy;

    public void Initialize(EnemyModel enemyModel)
    {
        enemy = enemyModel;
    }

    void Start()
    {
        rigidbodyEnemy = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        transformTarget = player.transform;
    }

    private void FixedUpdate()
    {
        Vector2 direction = (transformTarget.position - transform.position).normalized;
        rigidbodyEnemy.linearVelocity = direction * enemy.speed;

        if (enemy.health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
