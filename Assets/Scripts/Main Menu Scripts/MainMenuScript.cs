using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    //public TMP_Text tmp_Continue_Text;
    //public TMP_Text tmp_NewGame_Text;
    //public TMP_Text tmp_Settings_Text;
    //public TMP_Text tmp_Quit_Text;

    public GameObject warning_Message_Panel;

    // Main Menu
    public void MM_Button_Selector(int menu_Selector)
    {
        switch (menu_Selector)
        {
            case 0: // Continue
                MM_Continue();
                break;
            case 1: // New Game
                MM_New_Game();  
                break;
            case 2: // Settings
                MM_Settings();
                break;
            case 3: // Quit
                Application.Quit();
                break;
            case 4: // Option for No in Warning Panel
                warning_Message_Panel.SetActive(false);
                break;

        }
    }

    void MM_Continue() // If a save is detected, the game will load. If not throw an error.
    {
        warning_Message_Panel.SetActive(true);
    }

    void MM_New_Game() // Overwrites or creates a new game save. Wipes any current save.
    {
        SceneManager.LoadScene(0);
    }

    void MM_Settings()
    {

    }
}
