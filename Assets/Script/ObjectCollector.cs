using UnityEngine;

public class ObjectCollector : MonoBehaviour
{
    public int scoreValue = 10; // Punteggio di base per ogni oggetto raccolto
    public float maxTime = 5f; // Tempo massimo per ottenere il punteggio massimo
    public float timeBonusMultiplier = 2f; // Moltiplicatore del punteggio per il tempo rimanente

    private bool collected = false;
    private float collectTime;

    void OnTriggerEnter(Collider other)
    {
        if (!collected && other.CompareTag("PickupObject")) // Assicurati che l'oggetto sia stato raccolto solo una volta e che il collider appartenga al giocatore
        {
            collected = true;
            collectTime = Time.time;

            // Calcola il punteggio basato sul tempo trascorso
            float timeElapsed = Mathf.Clamp(maxTime - (Time.time - collectTime), 0f, maxTime);
            int timeBonus = Mathf.RoundToInt(timeElapsed * timeBonusMultiplier);

            // Calcola il punteggio totale
            int totalScore = scoreValue + timeBonus;

            // Aggiungi il punteggio al punteggio complessivo del giocatore
            // Ad esempio, se hai un sistema di punteggio globale, puoi usare ScoreManager.AddScore(totalScore);
            Debug.Log("Oggetto raccolto! Punteggio: " + totalScore);
        }
    }
}
