using UnityEngine;

public class CardApplier
{
    public static void CardApply(CardModel card)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.currentHealth += card.modifier.health;
        stats.moveSpeed += card.modifier.moveSpeed;
    }
}
