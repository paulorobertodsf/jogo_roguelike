using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth;
    [HideInInspector] public int currentHealth;
    public int damage;
    public int moveSpeed;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void Initialize(EnemyModel enemy)
    {
        maxHealth = enemy.health;
        currentHealth = enemy.health;
        damage = enemy.damage;
        moveSpeed = enemy.moveSpeed;
    }
}