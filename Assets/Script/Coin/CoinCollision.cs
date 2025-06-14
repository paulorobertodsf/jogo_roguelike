using UnityEngine;

public class CoinCollider : MonoBehaviour
{
    [SerializeField] private GameObject menuUpgrade;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player")) return;
        GameController.PauseGame();
        GameObject menuUpgradeInstace = Instantiate(menuUpgrade);
        MenuUpgradeController menuUpgradeController = menuUpgradeInstace.GetComponent<MenuUpgradeController>();
        menuUpgradeController.Initialize();
        GameController.ResumeGame();
        Destroy(gameObject);
    }
}