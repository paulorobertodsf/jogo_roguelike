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
}