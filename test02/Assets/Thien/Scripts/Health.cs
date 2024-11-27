using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float maxHP;
    public float currentHP;
    public virtual void TakeDamage(float damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Max(0, currentHP);
        Debug.Log("Zombie b? b?n! HP c�n l?i: " + currentHP);

        // N?u m�u v? 0, zombie ch?t
        if (currentHP <= 0)
        {
            Debug.Log("Zombie ?� ch?t!");
        }
    }
    private void Start()
    {
        currentHP = maxHP;
    }
}

