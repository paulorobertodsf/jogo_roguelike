using UnityEngine;
using UnityEngine.EventSystems;

public class CardView : MonoBehaviour, IPointerClickHandler
{
    public CardModel cardModel;

    public void Initialize(CardModel cardModel)
    {
        this.cardModel = cardModel;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        CardController.applyCard(cardModel);
        GameController.DestroyMenuUpgrade();
    }
}
