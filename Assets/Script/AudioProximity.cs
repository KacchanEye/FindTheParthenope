using UnityEngine;

public class AudioProximity : MonoBehaviour
{
    public Transform player; // Riferimento al trasform del giocatore
    public float maxVolumeDistance = 10f; // Distanza massima a cui il suono è udibile
    public float minVolumeDistance = 1f; // Distanza minima a cui il suono è udibile
    public float maxVolume = 1f; // Volume massimo del suono
    public float minVolume = 0f; // Volume minimo del suono

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Calcola la distanza tra l'oggetto e il giocatore
        float distance = Vector3.Distance(transform.position, player.position);

        // Limita la distanza tra la minima e la massima
        distance = Mathf.Clamp(distance, minVolumeDistance, maxVolumeDistance);

        // Calcola il volume in base alla distanza
        float volume = Mathf.InverseLerp(maxVolumeDistance, minVolumeDistance, distance);
        volume = Mathf.Lerp(minVolume, maxVolume, volume);

        // Imposta il volume dell'audio
        audioSource.volume = volume;
    }
}