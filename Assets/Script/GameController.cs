using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    public Text timeText;
    public GameObject gameOverPanel;
    public Text finalScoreText;
    public AudioSource pickupSound; 
    public AudioSource Endgame;
    public int initialScore = 1000; // Punteggio iniziale dell'oggetto
    private int score = 0;
    private int objectsCollected = 0;
    private int totalObjects = 1;
    private float timeElapsed = 0;
    private bool gameOver = false;
    public Text leaderboardText;
    public InputField nameInputField;
    [System.Serializable]
    public class PlayerData
    {
        public string playerName;
        public int playerScore;
    }
      public class DatiGiocatori
    {
        public List<PlayerData> giocatori = new List<PlayerData>();
    }
    PlayerData playerData = new PlayerData();

    void Start()
    {
        int valoreParametro = PlayerPrefs.GetInt("Vestiario");
           GameObject oggettoDaDistruggere = GameObject.Find("backpack");
           GameObject oggettoDaDistruggere1 = GameObject.Find("hat");

            Destroy(GameObject.Find("MenuAudio"));

        if(valoreParametro==1){
        if (oggettoDaDistruggere != null)
        {
            // Distruggi il GameObject trovato
            Destroy(oggettoDaDistruggere);
            Destroy(oggettoDaDistruggere1);
        }



        }else if(valoreParametro==2){


            Destroy(oggettoDaDistruggere1);


        }
        else if(valoreParametro==3){
            Destroy(oggettoDaDistruggere);

        }
        else if(valoreParametro==4){



        }
        // Verifica se è stato trovato un GameObject con il nome specificato
        




        gameOverPanel.SetActive(false);
        totalObjects = GameObject.FindGameObjectsWithTag("PickupObject").Length;
    }

    void Update()
    {
        if (!gameOver)
        {
            timeElapsed += Time.deltaTime;
            UpdateTimeUI();
        }
    }

    public void CollectObject(GameObject objToCollect)
    {
        pickupSound.Play();
        
        int collectedScore = initialScore - Mathf.RoundToInt(timeElapsed);
        if (collectedScore < 0)
        {
            collectedScore = 0;
        }
        score += collectedScore;

        objectsCollected++;
        UpdateScoreUI();
        objToCollect.SetActive(false);

        if (objectsCollected >= totalObjects)
        {
            EndGame();
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Punteggio: " + score.ToString();
    }

    void UpdateTimeUI()
    {
        timeText.text = "Tempo: " + TimeSpan.FromSeconds(timeElapsed).ToString("mm':'ss");
    }

    public void EndGame()
    {
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Endgame.Play();
        gameOver = true;
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Punteggio finale: " + score.ToString();
    }

    public void SaveScore()
    {
        playerData.playerName = nameInputField.text;
        playerData.playerScore = score;
         string fileName = "dati_classifica.json";
        string filePath = Path.Combine(Application.dataPath, fileName);

if (File.Exists(filePath))
        {
           
        // Leggi il JSON esistente
       string jsonEsistente = File.ReadAllText(filePath);

        // Converti il JSON in un oggetto C#
        DatiGiocatori datiGiocatori = JsonUtility.FromJson<DatiGiocatori>(jsonEsistente);

        datiGiocatori.giocatori.Add(playerData);

        string jsonAggiornato = JsonUtility.ToJson(datiGiocatori);

        // Scriviamo il JSON nel file
        File.WriteAllText(filePath, jsonAggiornato);

        Debug.Log("JSON salvato in: " + filePath);
    }else{

        File.WriteAllText(filePath,"{\"giocatori\":[{\"playerName\":\"poliperro\",\"playerScore\":42000}]}");
    }
        SceneManager.LoadScene("Menu");

}

}