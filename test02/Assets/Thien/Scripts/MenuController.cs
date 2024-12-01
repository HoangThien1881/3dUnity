using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button[] menuButtons; // Danh s�ch c�c n�t trong menu
    public Image gunPointer;     // H�nh c�y s�ng
    public Color normalColor = Color.white;  // M�u m?c ??nh c?a n�t
    public Color selectedColor = Color.green; // M�u khi n�t ???c ch?n
    public AudioClip selectSound; // �m thanh khi ch? v�o n�t m?i
    public AudioClip activateSound; // �m thanh khi n�t ???c k�ch ho?t

    private AudioSource audioSource; // Ngu?n ph�t �m thanh
    private int currentIndex = 0; // V? tr� hi?n t?i trong danh s�ch n�t

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // T?o AudioSource
        UpdateMenu();
    }

    void Update()
    {
        // Di chuy?n l�n
        if (Input.GetKeyDown(KeyCode.W))
        {
            currentIndex = (currentIndex - 1 + menuButtons.Length) % menuButtons.Length;
            PlaySelectSound();
            UpdateMenu();
        }

        // Di chuy?n xu?ng
        if (Input.GetKeyDown(KeyCode.S))
        {
            currentIndex = (currentIndex + 1) % menuButtons.Length;
            PlaySelectSound();
            UpdateMenu();
        }

        // K�ch ho?t n�t khi nh?n Enter
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            ActivateButton();
        }
    }

    void UpdateMenu()
    {
        // C?p nh?t m�u v� v? tr� c?a c�y s�ng
        for (int i = 0; i < menuButtons.Length; i++)
        {
            // ??i m�u n�t
            ColorBlock colors = menuButtons[i].colors;
            colors.normalColor = (i == currentIndex) ? selectedColor : normalColor;
            menuButtons[i].colors = colors;

            // Di chuy?n c�y s�ng
            if (i == currentIndex)
            {
                gunPointer.transform.position = menuButtons[i].transform.position;
            }
        }
    }

    void PlaySelectSound()
    {
        if (selectSound != null)
        {
            audioSource.PlayOneShot(selectSound);
        }
    }

    void ActivateButton()
    {
        if (activateSound != null)
        {
            audioSource.PlayOneShot(activateSound);
        }

        // G?i h�nh ??ng c?a n�t ???c ch?n
        menuButtons[currentIndex].onClick.Invoke();
    }
}
