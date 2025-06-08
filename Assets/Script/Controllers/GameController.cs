using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static string pathData = "Assets/Data";
    public static string pathPrefab = "Prefab";
    private static int limitCards = 3;
    public static void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public static void CreateMenuUpgrade(List<CardModel> cards)
    {
        PauseGame();
        GameObject menuUpgradePrefab = Resources.Load<GameObject>(pathPrefab + "/MenuUpgrade/Menu Upgrade");
        GameObject menuUpgradeInstance = Instantiate(menuUpgradePrefab);

        float spacing = 250f;
        float currentPosition = -250f;
        int currentCard = 1;

        foreach (CardModel cardModel in cards)
        {
            if (currentCard > limitCards) break;
            GameObject cardPrefab = Resources.Load<GameObject>(pathPrefab + "/MenuUpgrade/Card");

            Vector3 basePostion = menuUpgradeInstance.transform.position;
            Vector3 cardPosition = new Vector3(basePostion.x + currentPosition, basePostion.y, basePostion.z);
            currentPosition += spacing;

            GameObject cardInstance = Instantiate(cardPrefab, cardPosition, Quaternion.identity, menuUpgradeInstance.transform);
            InitializeCard(cardInstance, cardModel);
            currentCard++;
        }
    }

    public static void DestroyMenuUpgrade()
    {
        GameObject menuUpgrade = GameObject.FindGameObjectWithTag("MenuUpgrade");
        Destroy(menuUpgrade);
        ResumeGame();
    }

    private static GameObject InitializeCard(GameObject cardObject, CardModel cardModel)
    {
        TextMeshProUGUI description = cardObject.GetComponentInChildren<TextMeshProUGUI>();
        description.text = cardModel.name;
        return cardObject;
    }
}
