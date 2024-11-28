using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NPC : MonoBehaviour
{
    public GameObject NPCPanel; // B?ng tho?i c?a NPC
    public TextMeshProUGUI NPCTextContext; // Text hi?n th? n?i dung tho?i
    public string[] content; // N?i dung c�c d�ng tho?i
    Coroutine coroutine; // Bi?n d�ng ?? qu?n l� coroutine hi?n th? n?i dung
    public string nextSceneName; // T�n c?a scene b?n mu?n chuy?n ??n

    private void Start()
    {
        nextSceneName = "game3d"; // G�n tr?c ti?p t�n scene trong script
        NPCPanel.SetActive(true);
        NPCTextContext.text = "";
        coroutine = StartCoroutine(ReadContext());
        // Ki?m tra n?u c�c tham chi?u ?� ???c g�n
        if (NPCPanel == null || NPCTextContext == null)
        {
            Debug.LogError("Vui l�ng g�n NPCPanel v� NPCTextContext trong Inspector!");
            return;
        }

        // Hi?n th? b?ng tho?i ngay t? ??u
        NPCPanel.SetActive(true);
        NPCTextContext.text = ""; // ??t text ban ??u l� r?ng
        coroutine = StartCoroutine(ReadContext()); // B?t ??u ??c tho?i
    }

    IEnumerator ReadContext()
    {
        foreach (var line in content)
        {
            NPCTextContext.text = ""; // X�a text c? tr??c khi hi?n th? d�ng m?i
            for (int i = 0; i < line.Length; i++)
            {
                NPCTextContext.text += line[i]; // G� t?ng k� t?
                yield return new WaitForSeconds(0.1f); // ?i?u ch?nh t?c ?? g� ch?
            }
            yield return new WaitForSeconds(2); // Th?i gian ch? gi?a c�c d�ng tho?i
        }

        // ?n b?ng tho?i khi ho�n th�nh
        yield return new WaitForSeconds(5); // ??i 3 gi�y tr??c khi t?t b?ng tho?i
        ChangeScene();
    }
    public void ChangeScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName)) // Ki?m tra n?u t�n scene kh�ng r?ng
        {
            SceneManager.LoadScene("game3d"); // T?i scene m?i
        }
        else
        {
            Debug.LogError("T�n scene ch?a ???c g�n!");
        }
    }
}
