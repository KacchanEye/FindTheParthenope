using UnityEngine;
using UnityEngine.UI;

public class SalvaButton : MonoBehaviour
{
    // Riferimento allo script esterno
    public GameController externalScript;
        public Button save;
    // Metodo chiamato quando il pulsante viene premuto
     void Start()
    {
        // Verifica che lo script esterno non sia nullo
       if (save != null)
        {
            // Aggiungi un listener per l'evento OnClick del bottone
            save.onClick.AddListener(Save);
        }
        else
        {
            Debug.LogError("Button not assigned!");
        }
    }
     void Save()
    {
        // Avvia la scena del gioco
        externalScript.SaveScore();
    }
}
