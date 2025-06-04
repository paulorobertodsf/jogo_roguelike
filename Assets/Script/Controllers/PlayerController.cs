using Unity.VisualScripting;
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

    public int health;
    public float speed;

    public float fireCooldown;
    private float fireInterval;
    private float fireForce = 10f;

    private float damageCooldown = 0.1f;
    private float nextDamageTime = 0f;

    void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbodyPlayer.linearVelocity = movement * speed;
        if (health <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnMove(InputValue inputValue)
    {
        movement = inputValue.Get<Vector2>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && Time.time >= nextDamageTime)
        {
            EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();
            health -= enemyController.damage;

            nextDamageTime = Time.time + damageCooldown;
        }
    }

    private void OnFire()
    {
        FireBullet();
    }

    private void FireBullet()
    {
        if (Time.time < fireInterval) return;
        GameObject bullet = Instantiate(bulletPrefab, transformFirePoint.position, Quaternion.identity, transformBulletContainer);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();

        if (rbBullet != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector2 direction = (mousePos - transformFirePoint.position).normalized;
            rbBullet.linearVelocity = direction.normalized * fireForce;
        }

        Collider2D colliderPlayer = GetComponent<Collider2D>();
        Collider2D colliderBullet = bullet.GetComponent<Collider2D>();

        Physics2D.IgnoreCollision(colliderBullet, colliderPlayer);

        fireInterval = Time.time + fireCooldown;
    }
}
