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
    public GameObject endgame_Dax_Crowne;

    public void Keypad_Button_Press(int digit)
    {
        if (digit == 99)
        {
            Check_Combination();
        }
        else if (digit == 88)
        {
            Clear_Input();
        }
        else if (digit == 77)
        {
            Close_Keypad_UI();
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

    void Close_Keypad_UI()
    {
        keypad_UI.SetActive(false);
    }
}
