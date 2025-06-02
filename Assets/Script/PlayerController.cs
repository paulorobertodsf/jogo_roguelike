using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Vector2 movimento;
    Rigidbody2D rb;

    public GameObject prefabBullet;
    public Transform containerBullet;
    public Transform pontoDeDisparo;
    private float forcaDisparo = 10f;

    public int vida = 100;
    public float velocidade = 10f;
    
    private float tempoEntreDanos = 0.1f;
    private float proximoDano = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movimento * velocidade;
        if (vida <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnMove(InputValue inputValue)
    {
        movimento = inputValue.Get<Vector2>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && Time.time >= proximoDano)
        {
            EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();
            vida -= enemyController.dano;

            proximoDano = Time.time + tempoEntreDanos;
        }
    }

    private void OnFire()
    {
        if (prefabBullet != null && pontoDeDisparo != null)
        {
            GameObject bullet = Instantiate(prefabBullet, pontoDeDisparo.position, Quaternion.identity, containerBullet);
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();

            if (rbBullet != null)
            {
                Vector3 posMouse = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                Vector2 direcao = (posMouse - pontoDeDisparo.position).normalized;
                rbBullet.linearVelocity = direcao.normalized * forcaDisparo;
            }

            Collider2D colProjetil = bullet.GetComponent<Collider2D>();
            Collider2D colPlayer = GetComponent<Collider2D>();

            if (colProjetil != null && colPlayer != null)
            {
                Physics2D.IgnoreCollision(colProjetil, colPlayer);
            }
        }
    }
}
