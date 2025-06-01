using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    Vector2 movimento;
    Rigidbody2D rb;
    public float velocidade = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (rb != null)
        {
            rb.linearVelocity = movimento * velocidade;
        }
    }

    private void OnMove(InputValue inputValue)
    {
        movimento = inputValue.Get<Vector2>();
    }
}
