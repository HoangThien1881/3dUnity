using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light spotLight;            // ?�n c?n ch?p
    public float flickerSpeed = 0.1f;  // T?c ?? ch?p (??n v?: gi�y)

    private bool isFlickering = false;

    void Start()
    {
        if (spotLight == null)
        {
            spotLight = GetComponent<Light>();
        }

        // B?t ??u hi?u ?ng ch?p
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            spotLight.enabled = !spotLight.enabled;  // B?t ho?c t?t ?�n
            yield return new WaitForSeconds(flickerSpeed);  // T?m d?ng tr??c khi thay ??i tr?ng th�i
        }
    }
}
