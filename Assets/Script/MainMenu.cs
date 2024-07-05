using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private bool isCursorVisible = false;
    public GameObject menuPanel; // Il pannello del menu da mostrare/nascondere

    private void Start()
    {
         Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        // Nascondi il pannello del menu all'avvio del gioco
        if (menuPanel != null)
            menuPanel.SetActive(false);
    }

    private void Update()
    {
        // Controlla se il tasto Esc viene premuto
        if (Input.GetKeyDown(KeyCode.Escape))
        {
          

            
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
          
                
                menuPanel.SetActive(true);
                
            
        }
    }
}