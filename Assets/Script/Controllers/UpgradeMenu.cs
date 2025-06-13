using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class UpgradeMenu : MonoBehaviour
{
    /* TODO: tentar deixar essas cartas um pouco mais responsivas
     * não acreidto que deixar fixado em 250 seja bom kkkkkk
     * */
    private float spacingBetweenCards = 250f;
    private int limitCards = 3;
    private GameObject menuUpgradePrefab;
    private GameObject cardPrefab;
    private GameObject menuInstance;

    private void Awake()
    {
        cardPrefab = Resources.Load<GameObject>(GameController.pathPrefab + "Card");
        menuUpgradePrefab = Resources.Load<GameObject>(GameController.pathPrefab + "Menu Upgrade");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        GameController.PauseGame();
        List<CardModel> cards = CardManager.LoadCards();
        cards = CardManager.ShuffleCards(cards);
        cards = cards.Take(limitCards).ToList();
        DisplayCards(cards);
        Destroy(gameObject);
    }

    public void DisplayCards(List<CardModel> cards)
    {
        menuInstance = Instantiate(menuUpgradePrefab);
        Transform parent = menuInstance.transform;
        float currentSpacing = -250f;

        foreach (var card in cards)
        {
            Vector3 position = new Vector3(currentSpacing, 0f, 0f);
            GameObject cardInstance = Instantiate(cardPrefab, parent.position + position, Quaternion.identity, parent);
            CardView cardView = cardInstance.GetComponent<CardView>();
            cardView.Initialize(card);
            cardView.OnCardChosen += CloseMenu;
            currentSpacing += spacingBetweenCards;
        }
    }

    private void CloseMenu()
    {
        if (menuInstance != null)
            Destroy(menuInstance);

        GameController.ResumeGame();
    }
}
