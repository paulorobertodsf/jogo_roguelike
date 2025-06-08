using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public void UpdateHealthBar(int maxValue, int currentValue)
    {
        slider.value = (float) currentValue / maxValue;
    }
}
