using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    public Button closeButton;

    void Start()
    {
        if (closeButton != null)
        {
            // Aggiungi un listener per l'evento OnClick del bottone
            closeButton.onClick.AddListener(Close);
        }
        else
        {
            Debug.LogError("Button not assigned!");
        }
    }

    void Close()
    {
        // Chiudi l'applicazione
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
