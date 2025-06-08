using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class CardController : MonoBehaviour
{
    private static int limitCards = 3;

    public static List<CardModel> GetCards()
    {
        string jsonCard = "Cards.json";
        string pathCardJson = Path.Combine(GameController.pathData, jsonCard);

        string jsonContent = File.ReadAllText(pathCardJson);
        CardsWrapper cardsWrapper = JsonUtility.FromJson<CardsWrapper>(jsonContent);

        List<CardModel> cardsModel = cardsWrapper.cards;
        cardsModel = RandomizeCards(cardsModel);
        Debug.Log(cardsModel.ToString());
        return cardsModel;
    }

    private static List<CardModel> RandomizeCards(List<CardModel> cards)
    {
        cards = cards.OrderBy(x => Random.Range(0, cards.Count)).ToList();
        cards = cards.Take(limitCards).ToList();
        return cards;
    }

    public static void applyCard(CardModel card)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerController playerController = player.GetComponent<PlayerController>();
        Debug.Log(card.modifier);
        Debug.Log(playerController);
        playerController.currentHealth += card.modifier.health;
        playerController.speed += card.modifier.speed;
    }
}
