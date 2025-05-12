using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class KeypadScript : MonoBehaviour
{
    // Variables
    // Constants
    const int COMBINATION_ANSWER = 1138;
    const KeyCode INTERACT_KEY = KeyCode.E;

    // Everything else
    int input_Combination = 0;
    int digits_Entered = 0;

    bool player_Has_Module;
    bool dax_Crowne_Is_Disabled;

    bool is_Player_In_Range_Of_Module;
    bool is_Player_In_Range_Of_Keypad;

    // Game Objects
    // UI
    public TextMeshProUGUI display_Text_GUI;
    public GameObject keypad_UI;
    public GameObject main_UI;

    // Ending Stuff
    public GameObject ending_1_UI_Game_Object;
    public GameObject ending_2_UI_Game_Object;
    public GameObject ending_3_UI_Game_Object;
    public GameObject ending_4_UI_Game_Object;
    public GameObject ending_UI_Group_Game_Object;

    // Other
    public GameObject endgame_Dax_Crowne;
    public GameObject endgame_Module_Game_Object;

    public GameObject endgame_Trigger_Game_Object;


    private void Start()
    {
        endgame_Dax_Crowne.SetActive(true);
    }

    public void Keypad_Button_Press(int digit)
    {
        if (digit == 99)        // Check Combination, green if correct, red if false. || "Enter" Button
        {
            Check_Combination();
        }
        else if (digit == 88)   // Close Screen UI and Input || "<" Button
        {
            Clear_Input();
        }
        else if (digit == 77)   // Close Keypad UI || "X" Button
        {
            Toggle_Keypad_UI(false);
        }
        else
        {
            if (digits_Entered < 4)
            {
                input_Combination = input_Combination * 10 + digit;
                digits_Entered++;
                display_Text_GUI.text = input_Combination.ToString();

                Debug.Log("Input: " + input_Combination);
            }
        }


    }

    void Check_Combination()
    {
        if (input_Combination == COMBINATION_ANSWER)
        {
            display_Text_GUI.color = Color.green;
            endgame_Dax_Crowne.SetActive(false);
            dax_Crowne_Is_Disabled = true;
        }
        else
        {
            display_Text_GUI.color = Color.red;
        }
    }

    void Clear_Input()
    {
        input_Combination = 0;
        digits_Entered = 0;
        display_Text_GUI.text = "";
        display_Text_GUI.color = Color.white;
        Debug.Log("Cleared!");
    }

    void Toggle_Keypad_UI(bool active)
    {
        if (!active)
        {
            keypad_UI.SetActive(false);
            main_UI.SetActive(true);
        }
        else
        {
            keypad_UI.SetActive(true);
            main_UI.SetActive(false);
        }

    }

    void Check_Ending()
    {
        if (player_Has_Module && dax_Crowne_Is_Disabled) // Good ending (Player returns home and village is saved but hummanity dies off slowly.)
        {
            ending_1_UI_Game_Object.SetActive(true);
            ending_UI_Group_Game_Object.SetActive(true);
            Disable_All_UI();
        }

        else if (!player_Has_Module && dax_Crowne_Is_Disabled) // Good ending (Player returns home and the villages dies but hummanity lives on)
        {
            ending_2_UI_Game_Object.SetActive(true);
            ending_UI_Group_Game_Object.SetActive(true);
            Disable_All_UI();
        }

        else if (player_Has_Module && !dax_Crowne_Is_Disabled) // Worst ending (Player dies, village dies and humanity is doomed.)
        {
            ending_3_UI_Game_Object.SetActive(true);
            ending_UI_Group_Game_Object.SetActive(true);
            Disable_All_UI();
        }

        else if (!player_Has_Module && !dax_Crowne_Is_Disabled) // Okay ending (Player dies, village dies but humanity lives on.)
        {
            ending_4_UI_Game_Object.SetActive(true);
            ending_UI_Group_Game_Object.SetActive(true);
            Disable_All_UI();
        }
    }

    private void Disable_All_UI()
    {
        keypad_UI.SetActive(false);
        main_UI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("End_Game_Computer_Module"))  // Ensure the tag is "Player" for the player GameObject
        {
            is_Player_In_Range_Of_Module = true;  // Player is in range
        }

        if (other.CompareTag("Key_Pad_Tag"))  // Ensure the tag is "Player" for the player GameObject
        {
            is_Player_In_Range_Of_Keypad = true;  // Player is in range
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("End_Game_Computer_Module"))  // Ensure the tag is "Player" for the player GameObject
        {
            is_Player_In_Range_Of_Module = false;  // Player is in range
        }

        if (other.CompareTag("Key_Pad_Tag"))  // Ensure the tag is "Player" for the player GameObject
        {
            is_Player_In_Range_Of_Keypad = false;  // Player is in range
        }

        if (other.CompareTag("Bunker_Valoram_Tag"))
        {
            endgame_Trigger_Game_Object.SetActive(true);
        }

        if (other.CompareTag("Bunker_Endgame_Tag"))
        {
            Check_Ending();
        }
    }

    private void Update()
    {
        if (is_Player_In_Range_Of_Keypad && Input.GetKeyDown(INTERACT_KEY))
        {
            Toggle_Keypad_UI(true);
        }

        if (is_Player_In_Range_Of_Module && Input.GetKeyDown(INTERACT_KEY))
        {
            endgame_Module_Game_Object.SetActive(false);
            player_Has_Module = true;
        }
    }
}