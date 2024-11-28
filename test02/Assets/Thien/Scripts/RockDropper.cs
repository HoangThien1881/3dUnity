using UnityEngine;

public class RockDropper : MonoBehaviour
{
    public GameObject rockPrefab;  // Prefab c?a c?c ?�
    public Transform dropPoint;    // ?i?m ph�t ra c?c ?� (c� th? g�n v? tr� n�y trong Inspector)
    public float dropInterval = 5f;  // Th?i gian gi?a c�c l?n th? c?c ?�

    private float nextDropTime = 0f;  // Th?i gian ti?p theo ?? th? c?c ?�

    void Update()
    {
        // Ki?m tra th?i gian ?? th? c?c ?�
        if (Time.time >= nextDropTime)
        {
            DropRock();
            nextDropTime = Time.time + dropInterval; // C?p nh?t th?i gian ti?p theo ?? th? c?c ?�
        }
    }

    private void DropRock()
    {
        if (rockPrefab != null && dropPoint != null)
        {
            // Spawn c?c ?� t?i v? tr� th? ?�
            GameObject rock = Instantiate(rockPrefab, dropPoint.position, Quaternion.identity);

            // �p d?ng m?t l?c ?? c?c ?� r?i xu?ng (s? d?ng Rigidbody2D ?? �p d?ng tr?ng l?c)
            Rigidbody2D rb = rock.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = 1;  // B?t tr?ng l?c cho c?c ?�
                rb.isKinematic = false; // Cho ph�p c?c ?� b? ?nh h??ng b?i v?t l�
            }
        }
    }
}
