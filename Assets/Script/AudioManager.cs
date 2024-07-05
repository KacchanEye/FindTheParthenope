using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    private AudioSource musicSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            
            // Crea un nuovo AudioSource se non esiste
            musicSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(AudioClip musicClip, float volume)
    {
        musicSource.clip = musicClip;
        musicSource.volume = volume;
        musicSource.Play();
    }

    // Altri metodi per la gestione dell'audio...
}
