using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rigidbodyPlayer;

    public GameObject bulletPrefab;
    public Transform transformBulletContainer;
    public Transform transformFirePoint;
    private HealthBarController healthBar;

    public int maxHealth;
    private int currentHealth;

    public float speed;

    public float fireCooldown;
    private float fireInterval;
    private float fireForce = 10f;

    private float damageCooldown = 0.1f;
    private float nextDamageTime = 0f;

    private void Awake()
    {
        rigidbodyPlayer = GetComponent<Rigidbody2D>();
        healthBar = GetComponentInChildren<HealthBarController>();
    }

    private void Start()
    {

        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(maxHealth, currentHealth);
    }

    private void FixedUpdate()
    {
        rigidbodyPlayer.linearVelocity = movement * speed;
    }

    private void OnMove(InputValue inputValue)
    {
        movement = inputValue.Get<Vector2>();
    }
    private void OnFire()
    {
        FireBullet();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && Time.time >= nextDamageTime)
        {
            EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();
            TakeDamage(enemyController.damage);

            nextDamageTime = Time.time + damageCooldown;
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        healthBar.UpdateHealthBar(maxHealth, currentHealth);
    }

    private void FireBullet()
    {
        if (Time.time < fireInterval) return;
        GameObject bullet = Instantiate(bulletPrefab, transformFirePoint.position, Quaternion.identity, transformBulletContainer);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0f;
        Vector2 direction = (mousePos - transformFirePoint.position).normalized;

        if (rbBullet != null)
        {
            /*
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector2 direction = (mousePos - transformFirePoint.position).normalized;
            rbBullet.linearVelocity = direction.normalized * fireForce;*/
            rbBullet.linearVelocity = direction * fireForce;
        }

        BulletController bulletController = bullet.GetComponent<BulletController>();
        if (bulletController != null)
        {
            bulletController.direction = direction;
            bulletController.speed = fireForce;
        }
        
        Collider2D colliderPlayer = GetComponent<Collider2D>();
        Collider2D colliderBullet = bullet.GetComponent<Collider2D>();

        Physics2D.IgnoreCollision(colliderBullet, colliderPlayer);

        fireInterval = Time.time + fireCooldown;
    }
}
