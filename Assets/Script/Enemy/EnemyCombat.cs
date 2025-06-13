using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
public class EnemyCombat : MonoBehaviour
{
    private EnemyStats stats;

    private void Awake()
    {
        stats = GetComponent<EnemyStats>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerCombat playerCombat = collision.gameObject.GetComponent<PlayerCombat>();
            playerCombat.TakeDamage(stats.damage);
        }
    }

    public void TakeDamage(int damage)
    {
        stats.currentHealth -= damage;
        if (stats.currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
