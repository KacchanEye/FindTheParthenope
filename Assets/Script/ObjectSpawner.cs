using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // L'oggetto da spawnare
    public int numberOfObjects = 10; // Numero totale di oggetti da spawnare
    public Vector3 spawnAreaMin = new Vector3(-5f, 0f, -5f); // Punto minimo dell'area di spawn
    public Vector3 spawnAreaMax = new Vector3(5f, 0f, 5f); // Punto massimo dell'area di spawn

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomPosition = GetRandomPosition();
            float terrainHeight = Terrain.activeTerrain.SampleHeight(randomPosition); // Ottieni l'altezza del terreno
            randomPosition.y = terrainHeight+1; // Imposta l'altezza del terreno come altezza di spawn
            Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomZ = Random.Range(spawnAreaMin.z, spawnAreaMax.z);
        Vector3 randomPosition = new Vector3(randomX, 0f, randomZ) + transform.position;
        return randomPosition;
    }
}