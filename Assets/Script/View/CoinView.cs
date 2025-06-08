using System.Collections.Generic;
using UnityEngine;

public class CoinView : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        List<CardModel> listCard = CardController.GetCards();
        
        GameController.CreateMenuUpgrade(listCard);
        Destroy(gameObject);
    }
}
