using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayButtonHandler : MonoBehaviour
{
    // G�n TextMeshProUGUI c?a n�t
    [SerializeField] private TMP_Text playButtonText;

    // T�n scene c?n chuy?n
    [SerializeField] private string sceneName = "Cutscene";

    public void OnPlayButtonClick()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("T�n scene ch?a ???c ??t!");
        }
    }
}

