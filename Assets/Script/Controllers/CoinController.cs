using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("TESTE");
        if (!collision.gameObject.CompareTag("Player")) return;
        Destroy(gameObject);
    }
}
