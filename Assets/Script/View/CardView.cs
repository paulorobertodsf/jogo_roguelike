using UnityEngine;
using UnityEngine.EventSystems;

public class CardView : MonoBehaviour, IPointerClickHandler
{
    public CardModel card;

    public void Initialize(CardModel cardModel)
    {
        card = cardModel;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        CardController.applyCard(card);
        GameController.DestroyMenuUpgrade();
    }
}
