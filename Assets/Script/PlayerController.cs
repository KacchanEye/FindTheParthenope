using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float detectionRadius = 2f; // Raggio di rilevamento
    public GameController gameController;

    void Update()
    {
        // Rileva gli oggetti nelle vicinanze
    Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);
    
    foreach (Collider collider in colliders)
    {
        if (collider.CompareTag("PickupObject"))
        {
            // Chiama CollectObject del GameController e passa l'oggetto da raccogliere
            gameController.CollectObject(collider.gameObject);
        }
    }
    }

    void OnDrawGizmosSelected()
    {
        // Disegna una sfera di rilevamento per scopi di debug
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
