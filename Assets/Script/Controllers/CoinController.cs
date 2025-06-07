using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        List<CardModel> listCard = GetCards();
        
        GameController.CreateMenuUpgrade(listCard);
        Destroy(gameObject);
    }

    private List<CardModel> GetCards()
    {
        string jsonCard = "Cards.json";
        string pathCardJson = Path.Combine(GameController.pathData, jsonCard);

        string jsonContent = File.ReadAllText(pathCardJson);
        CardsWrapper cardsWrapper = JsonUtility.FromJson<CardsWrapper>(jsonContent);
        
        List<CardModel> cardsModel = cardsWrapper.cards;
        return cardsModel;
    }
}
