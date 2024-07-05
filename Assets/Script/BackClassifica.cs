using UnityEngine;
using UnityEngine.UI;

public class BackClassifica : MonoBehaviour
{
 public Button closeButton;
public GameObject menu;
public GameObject classifica;

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
        menu.SetActive(true); // Chiude il menu
        classifica.SetActive(false);
       
}
}
