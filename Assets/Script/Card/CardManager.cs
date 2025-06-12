using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class CardManager
{
    private static string jsonFileName = "Cards.json";

    public static List<CardModel> ShuffleCards(List<CardModel> cards)
    {
        cards = cards.OrderBy(x => Random.Range(0, cards.Count)).ToList();
        return cards;
    }

    public static List<CardModel> LoadCards()
    {
        string path = Path.Combine(GameController.pathData, jsonFileName);
        string json = File.ReadAllText(path);
        CardsWrapper wrapper = JsonUtility.FromJson<CardsWrapper>(json);
        return wrapper.cards;
    }
}