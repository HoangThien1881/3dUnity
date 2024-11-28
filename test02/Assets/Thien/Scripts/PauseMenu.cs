using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu; // Giao di?n PauseMenu
    private bool isPaused = false; // Tr?ng th�i t?m d?ng
    public PlayerInput playerInput;
    void Update()
    {
        if (isPaused) return; // Kh�ng x? l� n?u game ?ang t?m d?ng
                              // Code ?i?u khi?n nh�n v?t
    }


    public void Pause()
    {
        Debug.Log("Pause method called"); // D�ng ki?m tra
        if (pauseMenu == null)
        {
            Debug.LogError("PauseMenu is not assigned!");
            return;
        }

        pauseMenu.SetActive(true); // Hi?n th? giao di?n PauseMenu
        Time.timeScale = 0f;       // D?ng th?i gian trong game
        isPaused = true;           // C?p nh?t tr?ng th�i t?m d?ng
    }

    public void Resume()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
        Time.timeScale = 1f;
        isPaused = false;

        // ??m b?o Action Map c?a nh�n v?t ???c k�ch ho?t l?i
        playerInput.SwitchCurrentActionMap("Gameplay");
    }

    public void Home()
    {
        SceneManager.LoadScene(0); // Quay v? m�n h�nh ch�nh
        Time.timeScale = 1f;       // Kh�i ph?c th?i gian
    }
}
