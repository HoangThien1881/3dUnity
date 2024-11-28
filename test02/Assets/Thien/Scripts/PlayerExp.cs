using UnityEngine;
using System;

public class PlayerExp : MonoBehaviour
{
    public float currentExp = 0f; // EXP hi?n t?i c?a ng??i ch?i
    public float maxExp = 100f; // M?c EXP c?n ?? t?ng level
    public int level = 1; // M?c level c?a ng??i ch?i
    public float moveSpeed = 5f; // T?c ?? di chuy?n c?a ng??i ch?i
    public Health playerHealth; // Tham chi?u ??n Health

    public event Action<int> OnLevelUp; // S? ki?n khi ng??i ch?i l�n level

    // H�m c?ng EXP
    public void AddExp(float expAmount)
    {
        currentExp += expAmount;
        if (currentExp >= maxExp)
        {
            LevelUp();
        }
    }

    // H�m t?ng level
    private void LevelUp()
    {
        level++;
        currentExp = 0f; // Reset EXP
        maxExp *= 1.2f; // T?ng m?c EXP c?n thi?t cho level ti?p theo
        moveSpeed += 0.1f; // T?ng t?c ?? di chuy?n khi l�n level

        if (playerHealth != null)
        {
            playerHealth.IncreaseMaxHP(10f); // T?ng m�u t?i ?a 10 m?i l?n l�n level
        }

        OnLevelUp?.Invoke(level); // K�ch ho?t s? ki?n OnLevelUp
        Debug.Log("Level Up! Current Level: " + level + ", Speed: " + moveSpeed);
    }
}
