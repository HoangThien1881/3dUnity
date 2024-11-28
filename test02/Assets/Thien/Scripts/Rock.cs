using UnityEngine;

public class Rock : MonoBehaviour
{
    public float damage = 10f; // S�t th??ng c?a c?c ?�

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Ki?m tra xem va ch?m v?i ng??i ch?i kh�ng
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>(); // L?y component Health t? player
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // G?i ph??ng th?c TakeDamage ?? gi?m m�u ng??i ch?i
            }
            Destroy(gameObject); // X�a c?c ?� sau khi va ch?m
        }
     
    }
}
