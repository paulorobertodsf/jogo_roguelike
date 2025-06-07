using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void UpdateHealthBar(int maxValue, int currentValue)
    {
        slider.value = (float) currentValue / maxValue;
    }
}
