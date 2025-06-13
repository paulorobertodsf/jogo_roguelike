using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private WeaponBase startingWeapon;

    private WeaponBase currentWeapon;
    private PlayerStats stats;

    private void Awake()
    {
        stats = GetComponent<PlayerStats>();
        currentWeapon = startingWeapon;
    }

    public void Fire()
    {
        Debug.Log("FIRE!");
        currentWeapon.Use(firePoint, gameObject);
    }

    public void EquipWeapon(WeaponBase weapon)
    {
        currentWeapon = weapon;
    }

    public void TakeDamage(int damage)
    {
        stats.currentHealth -= damage;
        if (stats.currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
