using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHP; // M�u t?i ?a
    public float currentHP; // M�u hi?n t?i

    public virtual void TakeDamage(float damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Max(0, currentHP);
        Debug.Log("Nh�n v?t b? t?n c�ng! HP c�n l?i: " + currentHP);

        // N?u m�u v? 0, nh�n v?t ch?t
        if (currentHP <= 0)
        {
            Debug.Log("Nh�n v?t ?� ch?t!");
        }
    }

    private void Start()
    {
        currentHP = maxHP; // ??t m�u ??y khi b?t ??u
    }

    // H�m t?ng m�u t?i ?a v� h?i ??y m�u
    public void IncreaseMaxHP(float amount)
    {
        maxHP += amount; // T?ng m�u t?i ?a
        currentHP = maxHP; // H?i ??y m�u
        Debug.Log("T?ng m�u t?i ?a! HP hi?n t?i: " + currentHP);
    }
}
