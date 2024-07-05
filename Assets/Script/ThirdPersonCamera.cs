using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // Il personaggio da seguire
    public float distance = 5.0f; // Distanza della telecamera dal personaggio
    public float height = 3.0f; // Altezza della telecamera rispetto al personaggio
    public float mouseSensitivity = 2.0f; // Sensibilità del mouse per la rotazione della telecamera
    public float rotationSmoothTime = 0.12f; // Tempo di smooth per la rotazione della telecamera
    public Vector2 pitchMinMax = new Vector2(-40, 85); // Limiti di inclinazione della telecamera

    private Vector3 rotationSmoothVelocity; // Velocità di smooth per la rotazione della telecamera
    private Vector3 currentRotation; // Rotazione corrente della telecamera

    float yaw; // Angolo di yaw della telecamera
    float pitch; // Angolo di pitch della telecamera


void Start()
    {
        // Nascondi il cursore
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcola l'angolo di rotazione in base all'input del mouse
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

            // Calcola la rotazione corrente della telecamera
            currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);

            // Imposta l'angolo di rotazione della telecamera
            transform.eulerAngles = currentRotation;

            // Calcola la posizione della telecamera dietro il personaggio
            Vector3 targetPosition = target.position - transform.forward * distance;
            targetPosition.y = target.position.y + height;

            // Imposta la posizione della telecamera
            transform.position = targetPosition;
        }
    }
}
