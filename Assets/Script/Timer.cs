using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool timerRunning;

    void Start()
    {
        // Inizia il timer quando lo script viene avviato
        StartTimer();
    }

    void Update()
    {
        // Se il timer è in esecuzione, aggiorna il testo del timer
        if (timerRunning)
        {
            float elapsedTime = Time.time - startTime;
            UpdateTimerText(elapsedTime);
        }
    }

    void StartTimer()
    {
        // Avvia il timer
        startTime = Time.time;
        timerRunning = true;
    }

    void UpdateTimerText(float time)
    {
        // Formatta il tempo e aggiorna il testo del timer
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = "Tempo: " + timeString;
    }
}
