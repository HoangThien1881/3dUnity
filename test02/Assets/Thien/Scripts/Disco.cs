using UnityEngine;

public class DiscoEffect : MonoBehaviour
{
    public Light discoLight; // �nh s�ng t?o hi?u ?ng
    public AudioSource victoryMusic; // �m nh?c chi?n th?ng
    public ParticleSystem confettiEffect; // Hi?u ?ng ph�o hoa (n?u c�)

    public float colorChangeSpeed = 5f; // T?c ?? ??i m�u
    private bool isDiscoActive = false; // Tr?ng th�i hi?u ?ng disco

    private void Update()
    {
        if (isDiscoActive && discoLight != null)
        {
            // ??i m�u �nh s�ng li�n t?c
            discoLight.color = new Color(
                Mathf.Sin(Time.time * colorChangeSpeed),
                Mathf.Sin(Time.time * colorChangeSpeed + 2f),
                Mathf.Sin(Time.time * colorChangeSpeed + 4f)
            );
        }
    }

    public void StartDisco()
    {
        if (isDiscoActive) return; // N?u ?ang ch?y, kh�ng k�ch ho?t l?i

        isDiscoActive = true;

        // B?t �nh s�ng
        if (discoLight != null)
            discoLight.enabled = true;

        // Ph�t nh?c chi?n th?ng
        if (victoryMusic != null)
            victoryMusic.Play();

        // K�ch ho?t hi?u ?ng ph�o hoa
        if (confettiEffect != null)
            confettiEffect.Play();

        Debug.Log("Disco Time! Ch�c m?ng chi?n th?ng!");
    }

    public void StopDisco()
    {
        isDiscoActive = false;

        // T?t �nh s�ng
        if (discoLight != null)
            discoLight.enabled = false;

        // D?ng nh?c
        if (victoryMusic != null)
            victoryMusic.Stop();

        // D?ng hi?u ?ng ph�o hoa
        if (confettiEffect != null)
            confettiEffect.Stop();
    }
}
