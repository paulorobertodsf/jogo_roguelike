using UnityEngine;

public class CardController : MonoBehaviour
{
    private GameObject menuUpgrade;
    public void Click()
    {
        menuUpgrade = GameObject.FindGameObjectWithTag("MenuUpgrade");
        GameController.DestroyMenuUpgrade();
    }
}
