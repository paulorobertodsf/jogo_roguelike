using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public float moveSpeed;

    private HealthBar healthBar;

    private int _currentHealth;
    public int currentHealth
    {
        get => _currentHealth;
        set
        {
            _currentHealth = value;
            healthBar.SetHealth(_currentHealth);
        }
    }

    private void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
}
