using System;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float lifeTime;
    public int damage;
    public float speed;
    public Vector2 direction;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.position += (Vector3)(direction.normalized * speed * Time.deltaTime);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        if (!collision.gameObject.CompareTag("Enemy")) return;
        EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();

        enemy.health -= damage;
    }
}
