using UnityEngine;

public class MoveObjectUp : MonoBehaviour
{
    public string targetTag = "PickupObject"; // Il tag dell'oggetto che si desidera controllare
    public float positiveY = 1.0f; // L'altezza Y positiva a cui spostare l'oggetto

    void Update()
    {
        // Trova tutti gli oggetti con il tag specificato
        GameObject[] objects = GameObject.FindGameObjectsWithTag(targetTag);

        // Itera su ogni oggetto trovato
        foreach (GameObject obj in objects)
        {
            // Controlla se l'oggetto si trova ad un'altezza Y negativa
            if (obj.transform.position.y < 0)
            {
                // Sposta l'oggetto ad un'altezza Y positiva
                Vector3 newPos = obj.transform.position;
                newPos.y = positiveY;
                obj.transform.position = newPos;
            }
        }
    }
}
