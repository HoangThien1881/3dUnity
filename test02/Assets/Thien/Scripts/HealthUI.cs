using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Slider healthSlider;   // Tham chi?u ??n Slider
    public Health playerHealth;  // Tham chi?u ??n script Health c?a nh�n v?t

    void Start()
    {
        // ??t gi� tr? ban ??u
        healthSlider.maxValue = playerHealth.maxHP;
        healthSlider.value = playerHealth.currentHP;
    }

    void Update()
    {
        // C?p nh?t gi� tr? Slider d?a v�o m�u c?a nh�n v?t
        healthSlider.value = playerHealth.currentHP;
    }
}
