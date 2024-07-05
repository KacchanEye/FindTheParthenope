using UnityEngine;
using UnityEngine.UI;

public class ObjectCounter : MonoBehaviour
{
    public string tagToCount = "YourTagHere";
    private int objectCount;
    public Text countText; // Riferimento al componente di testo UI

    // Aggiorna il conteggio degli oggetti ogni frame
    void Update()
    {
        // Conta quanti oggetti con il tag specificato sono presenti nella scena
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tagToCount);
        objectCount = objectsWithTag.Length;
        
        // Aggiorna il testo con il conteggio degli oggetti
        countText.text = "Medaglioni Rimasti: " + objectCount;
    }
}
