using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    void Start()
    {
        // Imposta il valore iniziale dello slider al volume corrente dell'audio source
        volumeSlider.value = audioSource.volume;
        // Aggiunge un listener per rilevare i cambiamenti dello slider
        volumeSlider.onValueChanged.AddListener(delegate { OnVolumeChanged(); });
    }

    // Funzione chiamata quando il valore dello slider cambia
    void OnVolumeChanged()
    {
        // Imposta il volume dell'audio source in base al valore dello slider
        audioSource.volume = volumeSlider.value;
    }
}
