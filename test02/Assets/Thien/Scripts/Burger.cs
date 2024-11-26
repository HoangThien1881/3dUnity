using UnityEngine;

public class Burger : MonoBehaviour
{
    public float rotationSpeed = 50f;  // T?c ?? xoay c?a burger
    public float healAmount = 20f;     // S? m�u h?i khi ch?m v�o burger
    public Health playerHealth;        // Tham chi?u ??n script Health c?a ng??i ch?i

    void Update()
    {
        // Xoay burger li�n t?c
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ki?m tra n?u ??i t??ng va ch?m l� Player
        if (other.gameObject.CompareTag("Player"))
        {
            // H?i m�u cho ng??i ch?i
            var healthScript = other.GetComponent<Health>();
            if (healthScript != null)
            {
                healthScript.TakeDamage(-healAmount); // Ch?a b?ng c�ch gi?m damage (�m)
                Debug.Log("H?i m�u 20!");
                Destroy(gameObject);
            }
        }
    }
}
