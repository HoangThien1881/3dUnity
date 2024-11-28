using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu; // Giao diện PauseMenu
    private bool isPaused = false; // Trạng thái tạm dừng
    public PlayerInput playerInput;
    void Update()
    {
        if (isPaused) return; // Không xử lý nếu game đang tạm dừng
                              // Code điều khiển nhân vật
    }


    public void Pause()
    {
        Debug.Log("Pause method called"); // Dòng kiểm tra
        if (pauseMenu == null)
        {
            Debug.LogError("PauseMenu is not assigned!");
            return;
        }

        pauseMenu.SetActive(true); // Hiển thị giao diện PauseMenu
        Time.timeScale = 0f;       // Dừng thời gian trong game
        isPaused = true;           // Cập nhật trạng thái tạm dừng
    }

    public void Resume()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
        Time.timeScale = 1f;
        isPaused = false;

        // Đảm bảo Action Map của nhân vật được kích hoạt lại
        playerInput.SwitchCurrentActionMap("Gameplay");
    }

    public void Home()
    {
        SceneManager.LoadScene(0); // Quay về màn hình chính
        Time.timeScale = 1f;       // Khôi phục thời gian
    }
}
