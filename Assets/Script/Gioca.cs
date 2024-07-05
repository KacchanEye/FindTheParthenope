using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gioca : MonoBehaviour
{
    public Button GiocaButton;
    public int valoreParametro;
    public string sceneName = "World"; // Inserisci il nome della scena del gioco

    void Start()
    {
        // Assicurati che startButton sia collegato correttamente nell'editor Unity
        if (GiocaButton != null)
        {
            // Aggiungi un listener per l'evento OnClick del bottone
            GiocaButton.onClick.AddListener(StartGameOnClick);
        }
        else
        {
            Debug.LogError("Button not assigned!");
        }
    }

    void StartGameOnClick()
    {
        // Avvia la scena del gioco
        PlayerPrefs.SetInt("Vestiario", valoreParametro);

        SceneManager.LoadScene(sceneName);
    }
}