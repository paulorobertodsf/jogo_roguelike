using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerView : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rigidbodyPlayer;

    private HealthBarView healthBar;

    [SerializeField] public PlayerModel player;

    private void Awake()
    {
        rigidbodyPlayer = GetComponent<Rigidbody2D>();
        healthBar = GetComponentInChildren<HealthBarView>();
    }

    private void Start()
    {
        // TODO: colocar pra pegar as infos de um json
        player.currentHealth = player.maxHealth;
        HealthBarController.UpdateHealthBar(player.maxHealth, player.currentHealth);
    }

    private void FixedUpdate()
    {
        rigidbodyPlayer.linearVelocity = movement * player.speed;
    }

    private void OnMove(InputValue inputValue)
    {
        movement = inputValue.Get<Vector2>();
    }
    private void OnFire()
    {
        PlayerController.FireBullet();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && Time.time >= PlayerController.nextDamageTime)
        {
            EnemyView enemyView = collision.gameObject.GetComponent<EnemyView>();
            PlayerController.TakeDamage(enemyView.enemy.damage);

            PlayerController.nextDamageTime = Time.time + PlayerController.damageCooldown;
        }
    }
}
