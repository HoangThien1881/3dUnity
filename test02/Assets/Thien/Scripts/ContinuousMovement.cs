using UnityEngine;

public class ContinuousMovement : MonoBehaviour
{
    public float speed = 5f; // T?c ?? di chuy?n
    public Vector3 direction = Vector3.forward; // H??ng di chuy?n (m?c ??nh l� ?i th?ng)

    private Rigidbody rb;

    void Start()
    {
        // Ki?m tra v� g?n th�nh ph?n Rigidbody
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true; // ??t th�nh isKinematic ?? kh�ng ?nh h??ng b?i v?t l�
        }
    }

    void Update()
    {
        // Di chuy?n nh�n v?t li�n t?c theo h??ng
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }
}
