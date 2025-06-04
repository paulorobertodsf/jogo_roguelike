using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float lifeTime;
    public int damage;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        if (!collision.gameObject.CompareTag("Enemy")) return;
        EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();

        enemy.health -= damage;
    }
}
