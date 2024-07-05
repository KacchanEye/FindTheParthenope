using UnityEngine;
using UnityEngine.UI;

public class CloseMenuAndHideCursor : MonoBehaviour
{
 public Button closeButton;
public GameObject menu;

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
       menu.SetActive(false); // Chiude il menu

        Cursor.visible = false; // Imposta il cursore come invisibile
        Cursor.lockState = CursorLockMode.Locked; // Blocca il cursore al centro dello schermo (opzionale)    }
    
}
}

   