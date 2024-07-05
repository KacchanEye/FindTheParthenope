using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class FootstepSound : MonoBehaviour
{
    public float minVelocity = 0.1f; // Velocità minima per riprodurre i passi
    public AudioClip footstepSoundClip; // Audio dei passi

    private AudioSource footstepSound;
    private Rigidbody rb;

    void Start()
    {
        footstepSound = GetComponent<AudioSource>();
        footstepSound.clip = footstepSoundClip;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Controlla se il personaggio sta muovendosi
        if (rb.velocity.magnitude > minVelocity && !footstepSound.isPlaying)
        {
            // Riproduci l'audio dei passi se il personaggio sta camminando
            footstepSound.Play();
        }
    }
}
