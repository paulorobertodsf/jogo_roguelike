using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireCooldown = 0.3f;
    public float bulletForce = 10f;

    private float nextFireTime;
    private PlayerStats stats;

    private void Awake()
    {
        stats = GetComponent<PlayerStats>();
    }

    public void Fire()
    {
        // TODO: passar toda essa logica pra uma futura classe de armas
        if (Time.time < nextFireTime) return;

        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0f;

        Vector2 direction = (mouseWorldPosition - firePoint.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        BulletController bulletController = bullet.GetComponent<BulletController>();

        bulletController.direction = direction;
        bulletController.speed = bulletForce;
        rb.linearVelocity = direction * bulletForce;

        Collider2D playerCollider = GetComponent<Collider2D>();
        Collider2D bulletCollider = bullet.GetComponent<Collider2D>();

        Physics2D.IgnoreCollision(bulletCollider, playerCollider);

        nextFireTime = Time.time + fireCooldown;
    }

    public void TakeDamage(int damage)
    {
        stats.currentHealth -= damage;
        if (stats.currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
