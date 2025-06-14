using UnityEngine;

public class CoinCollider : MonoBehaviour
{
    [SerializeField] private GameObject menuUpgrade;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameController.PauseGame();
        GameObject menuUpgradeInstace = Instantiate(menuUpgrade);
        MenuUpgradeController menuUpgradeController = menuUpgradeInstace.GetComponent<MenuUpgradeController>();
        menuUpgradeController.Initialize();
        GameController.ResumeGame();
        Destroy(gameObject);
    }
}