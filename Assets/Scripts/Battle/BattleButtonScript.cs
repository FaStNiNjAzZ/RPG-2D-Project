using UnityEngine;
using TMPro;

public class BattleButtonScript : MonoBehaviour
{
    public GameObject base_Button_Battle_Panel;
    public GameObject talk_Button_Battle_Panel;
    public TMP_Text info_Text;

    public void Option_Selector(int selector)
    {
        switch (selector)
        {
            case 0: // Attack Button

                break;
            case 1: // Talk Button
                base_Button_Battle_Panel.SetActive(false);
                talk_Button_Battle_Panel.SetActive(true);
                break;
            case 2: // Talk -> Negotiate
                break;
            case 3: // Talk -> Intimidate
                break;
            case 4: // Talk -> Taunt

                break;
            case 5: // Talk -> Back
                talk_Button_Battle_Panel.SetActive(false);
                base_Button_Battle_Panel.SetActive(true);
                break;
        }
    }

    public void Option_Selector_Hover(int selector)
    {
        switch (selector)
        {
            case 0: // Attack Button

                break;
            case 1: // Talk Button

                break;
            case 2: // Talk -> Negotiate
                info_Text.text = "Negotiate - Avoid combat or enemies have increased damage. Chances of success is: {INVALID}";
                break;
            case 3: // Talk -> Intimidate
                info_Text.text = "Intimidate - Enemies have decreased accuracy or enemies gain increased accuracy. Chances of success is: {INVALID}";
                break;
            case 4: // Talk -> Taunt
                info_Text.text = "Taunt - Player gains an increase in accuracy or Player gains a decrease in accuracy. Chances of success is: {INVALID}";
                break;
            case 99: // Clear text info when not hovering
                info_Text.text = "";
                break;
        }
    }
}
