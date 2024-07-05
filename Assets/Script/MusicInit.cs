using UnityEngine;

public class MusicInit : MonoBehaviour
{
    public AudioClip musicClip;
    public float volume = 1f;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null)
        {
            audioManager.PlayMusic(musicClip, volume);
        }
    }
}
