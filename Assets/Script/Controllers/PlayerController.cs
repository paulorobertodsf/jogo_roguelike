using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static float fireCooldown;
    public static float fireInterval;
    public static float fireForce = 10f;

    public static float damageCooldown = 0.1f;
    public static float nextDamageTime = 0f;

    public static void TakeDamage(int damage)
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        PlayerView playerView = playerObject.GetComponent<PlayerView>();

        playerView.player.currentHealth -= damage;
        if (playerView.player.currentHealth <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        HealthBarController.UpdateHealthBar(playerView.player.maxHealth, playerView.player.currentHealth);
    }
    public static void FireBullet()
    {
        if (Time.time < fireInterval) return;
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        PlayerView playerView = playerObject.GetComponent<PlayerView>();

        GameObject firePoint = GameObject.FindGameObjectWithTag("FirePoint");
        Transform firePointTransform = firePoint.transform;

        GameObject bulletContainer = GameObject.FindGameObjectWithTag("BulletContainer");
        Transform bulletContainerTransform = firePoint.transform;

        GameObject bulletPrefab = Resources.Load<GameObject>(GameController.pathPrefab + "/Bullet");

        GameObject bullet = Instantiate(bulletPrefab, firePointTransform.position, Quaternion.identity, bulletContainerTransform);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0f;
        Vector2 direction = (mousePos - firePointTransform.position).normalized;

        rbBullet.linearVelocity = direction * fireForce;

        BulletController bulletController = bullet.GetComponent<BulletController>();
        if (bulletController != null)
        {
            bulletController.direction = direction;
            bulletController.speed = fireForce;
        }
        
        Collider2D colliderPlayer = playerObject.GetComponent<Collider2D>();
        Collider2D colliderBullet = bullet.GetComponent<Collider2D>();

        Physics2D.IgnoreCollision(colliderBullet, colliderPlayer);

        fireInterval = Time.time + fireCooldown;
    }
}
