using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Slider healthSlider;   // Tham chi?u ??n Slider
    public Health playerHealth;  // Tham chi?u ??n script Health c?a nhân v?t

    void Start()
    {
        // ??t giá tr? ban ??u
        healthSlider.maxValue = playerHealth.maxHP;
        healthSlider.value = playerHealth.currentHP;
    }

    void Update()
    {
        // C?p nh?t giá tr? Slider d?a vào máu c?a nhân v?t
        healthSlider.value = playerHealth.currentHP;
    }
}
