using UnityEngine;

public class HelpButtonHandler : MonoBehaviour
{
    // Panel h??ng d?n (g?n trong Inspector)
    [SerializeField] private GameObject helpPanel;

    // H�m x? l� khi b?m n�t Help
    public void OnHelpButtonClick()
    {
        if (helpPanel != null)
        {
            // Hi?n th? ho?c ?n panel h??ng d?n
            bool isActive = helpPanel.activeSelf;
            helpPanel.SetActive(!isActive);
        }
        else
        {
            Debug.LogError("Help Panel ch?a ???c g�n trong Inspector!");
        }
    }
}
