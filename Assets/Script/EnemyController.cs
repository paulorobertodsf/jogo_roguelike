using UnityEngine;

public class EnemyController : MonoBehaviour
{

    Rigidbody2D rb;
    public Transform alvo;
    public float velocidade = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            alvo = player.transform;
        }
    }

    private void FixedUpdate()
    {
        Vector2 direcao = (alvo.position - transform.position).normalized;
        rb.linearVelocity = direcao * velocidade;
    }
}
