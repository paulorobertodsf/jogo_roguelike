using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float tempoDeVida = 2f;
    public int dano = 5;

    void Start()
    {
        Destroy(gameObject, tempoDeVida);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (!collision.gameObject.CompareTag("Enemy")) return;
        EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();

        enemy.vida -= dano;
    }
}
