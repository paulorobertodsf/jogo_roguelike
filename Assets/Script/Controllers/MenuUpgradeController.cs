using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MenuUpgradeController : MonoBehaviour
{
    /* TODO: tentar deixar essas cartas um pouco mais responsivas
     * não acreidto que deixar fixado em 250 seja bom kkkkkk
     * */
    private float spacingBetweenCards = 250f;
    private int limitCards = 3;
    [SerializeField] private GameObject cardPrefab;

    public void Initialize()
    {
        List<CardModel> cards = CardManager.LoadCards();
        cards = CardManager.ShuffleCards(cards);
        cards = cards.Take(limitCards).ToList();
        DisplayCards(cards);
    }

    private void DisplayCards(List<CardModel> cards)
    {
        float currentSpacing = -250f;

        foreach (var card in cards)
        {
            Vector3 position = new Vector3(currentSpacing, 0f, 0f);
            GameObject cardInstance = Instantiate(cardPrefab, transform.position + position, Quaternion.identity, transform);
            CardView cardView = cardInstance.GetComponent<CardView>();
            cardView.Initialize(card);
            cardView.OnCardChosen = CloseMenu;
            currentSpacing += spacingBetweenCards;
        }
    }

    private void CloseMenu()
    {
        Destroy(gameObject);
    }
}
