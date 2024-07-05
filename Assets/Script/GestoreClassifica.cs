using UnityEngine;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI; 
using System.Linq;
public class GestoreClassifica : MonoBehaviour
{
    public string nomeFileJson;
    private Classifica classifica;
    public GameObject rigaClassificaPrefab; // Prefab della riga della classifica
    public Transform contenitoreClassifica; // Il contenitore dove verranno aggiunte le righe della classifica
    public float distanzaTraRighe = 50f; // Distanza tra ogni riga della classifica
    public float limiteY = 500f; // Limite di altezza per fermare la creazione di nuove righe
    private float posY = 0f; // Posizione y corrente per la nuova riga della classifica
    private int i;
    void Start()
    {
        // Leggi il file JSON e carica i dati della classifica
                 string fileName = "dati_classifica.json";

        string filePath = Path.Combine(Application.dataPath, fileName);
        string json = File.ReadAllText(filePath);
        Classifica classifica = JsonUtility.FromJson<Classifica>(json);

        // Ordina i giocatori in base al punteggio, dal più alto al più basso
        classifica.giocatori = classifica.giocatori.OrderByDescending(g => g.playerScore).ToArray();

        // Itera attraverso ogni giocatore nella classifica e crea una riga della classifica
        i=0;
        foreach (var giocatore in classifica.giocatori)
        {
            i++;
            // Se abbiamo raggiunto il limite di altezza, esci dal ciclo
            if (posY > limiteY)
                break;

            // Istanzia una nuova riga della classifica dalla prefab
            GameObject nuovaRigaClassifica = Instantiate(rigaClassificaPrefab, contenitoreClassifica);

            // Imposta la posizione della nuova riga della classifica
            RectTransform rectTransform = nuovaRigaClassifica.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0, posY);

            // Incrementa la posizione y per la prossima riga della classifica
            posY -= distanzaTraRighe;

            // Ottieni i riferimenti agli oggetti di testo nella nuova riga della classifica
            Text posgiocatore = nuovaRigaClassifica.transform.Find("posgiocatore").GetComponent<Text>();
            Text testoNome = nuovaRigaClassifica.transform.Find("Nome").GetComponent<Text>();
            Text testoPunteggio = nuovaRigaClassifica.transform.Find("Punteggio").GetComponent<Text>();

            // Assegna i dati del giocatore agli oggetti di testo
            posgiocatore.text = i.ToString();
            testoNome.text = giocatore.playerName;
            testoPunteggio.text = giocatore.playerScore.ToString();
        }
    }
}

[System.Serializable]
public class Classifica
{
    public Giocatore[] giocatori;
}

[System.Serializable]
public class Giocatore
{
    public string playerName;
    public int playerScore;
}
