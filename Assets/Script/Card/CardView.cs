using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class CardView : MonoBehaviour, IPointerClickHandler
{
    private CardModel card;
    private TextMeshProUGUI description;
    public Action OnCardChosen;

    private void Awake()
    {
        description = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Initialize(CardModel model)
    {
        card = model;
        description.text = model.description;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        CardApplier.CardApply(card);
        OnCardChosen.Invoke();
    }
}
