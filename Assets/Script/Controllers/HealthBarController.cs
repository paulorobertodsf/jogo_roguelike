using UnityEngine;
using UnityEngine.UI;

public class HealthBarController
{
    public static void UpdateHealthBar(int maxValue, int currentValue)
    {
        GameObject healthBar = GameObject.FindGameObjectWithTag("HealthBar");
        Slider slider = healthBar.GetComponent<Slider>();

        slider.value = (float)currentValue / maxValue;
    }
}