using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        List<CardModel> listCard = CardController.GetCards();
        
        GameController.CreateMenuUpgrade(listCard);
        Destroy(gameObject);
    }
}
