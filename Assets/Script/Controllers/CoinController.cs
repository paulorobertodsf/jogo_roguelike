using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        Destroy(gameObject);
    }
}
