using UnityEngine;
using TMPro;

public class KeypadScript : MonoBehaviour
{
    // Variables
    const int COMBINATION_ANSWER = 1138;
    int input_Combination = 0;
    int digits_Entered = 0;

    // Game Objects
    public TextMeshProUGUI display_Text_GUI;
    public GameObject keypad_UI;
    public GameObject main_UI;
    public GameObject endgame_Dax_Crowne;

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
}
