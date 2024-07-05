using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackMenu : MonoBehaviour
{
    public Button Back;
    public string sceneName = "Menu"; // Inserisci il nome della scena del gioco

    void Start()
    {
        // Assicurati che startButton sia collegato correttamente nell'editor Unity
        if (Back != null)
        {
            // Aggiungi un listener per l'evento OnClick del bottone
            Back.onClick.AddListener(StartGameOnClick);
        }
        else
        {
            Debug.LogError("Button not assigned!");
        }
    }

    void StartGameOnClick()
    {
        // Avvia la scena del gioco
        SceneManager.LoadScene(sceneName);
    }
}