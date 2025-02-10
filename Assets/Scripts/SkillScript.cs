using UnityEngine;
using TMPro;

public class SkillScript : MonoBehaviour
{
    // Variables
    // All skills, 0 is minimum, 100 is max.
    public int avaliable_Skill_Points = 300;
    public int speech_Skill = 0; // Unlocks dialog options with NPCs
    public int strength_Skill = 0; // Helps with intimidation
    public int charisma_Skill = 0; // Helps with negotiation
    public int provocation_Skill = 0; // Helps with Taunting
    public int dexterity_Skill = 0; // Helps with accuracy
    public int deadEye_Skill = 0;//Helps with increasing damage

    int point_Cost = 25;

    // Game Objects
    public TMP_Text avaliable_Points_Text;
    public TMP_Text speech_Text;
    public TMP_Text strength_Text;
    public TMP_Text charisma_Text;
    public TMP_Text provocation_Text;
    public TMP_Text dexterity_Text;
    public TMP_Text deadEye_Text;

    public GameObject skill_UI_Canvas;

    // Functions
    public void Skill_Menu_Selection(int selector)
    {
        if (avaliable_Skill_Points > 0 || (selector % 2) != 0) // Selector % 2 != 0 is for decrease button to still work if the player runs out of skill points.
        {
            switch (selector)
            {
                case 0:
                    if (speech_Skill < 100)
                    {
                        speech_Skill += point_Cost;
                        avaliable_Skill_Points -= point_Cost;
                    }
                    break;
                case 1:
                    if (speech_Skill > 0)
                    {
                        speech_Skill -= point_Cost;
                        avaliable_Skill_Points += point_Cost;
                    }
                    break;

                case 2:
                    if (strength_Skill < 100)
                    {
                        strength_Skill += point_Cost;
                        avaliable_Skill_Points -= point_Cost;
                    }
                    break;
                case 3:
                    if (strength_Skill > 0)
                    {
                        strength_Skill -= point_Cost;
                        avaliable_Skill_Points += point_Cost;
                    }
                    break;

                case 4:
                    if (charisma_Skill < 100)
                    {
                        charisma_Skill += point_Cost;
                        avaliable_Skill_Points -= point_Cost;
                    }
                    break;
                case 5:
                    if (charisma_Skill > 0)
                    {
                        charisma_Skill -= point_Cost;
                        avaliable_Skill_Points += point_Cost;
                    }
                    break;

                case 6:
                    if (provocation_Skill < 100)
                    {
                        provocation_Skill += point_Cost;
                        avaliable_Skill_Points -= point_Cost;
                    }
                    break;
                case 7:
                    if (provocation_Skill > 0)
                    {
                        provocation_Skill -= point_Cost;
                        avaliable_Skill_Points += point_Cost;
                    }
                    break;

                case 8:
                    if (dexterity_Skill < 100)
                    {
                        dexterity_Skill += point_Cost;
                        avaliable_Skill_Points -= point_Cost;
                    }
                    break;
                case 9:
                    if (dexterity_Skill > 0)
                    {
                        dexterity_Skill -= point_Cost;
                        avaliable_Skill_Points += point_Cost;
                    }
                    break;

                case 10:
                    if (deadEye_Skill < 100)
                    {
                        deadEye_Skill += point_Cost;
                        avaliable_Skill_Points -= point_Cost;
                    }
                    break;
                case 11:
                    if (deadEye_Skill > 0)
                    {
                        deadEye_Skill -= point_Cost;
                        avaliable_Skill_Points += point_Cost;
                    }
                    break;

                // Other
                case 99:
                    skill_UI_Canvas.SetActive(false);
                    break;
            }

            avaliable_Points_Text.text = avaliable_Skill_Points.ToString() + "/250";
            speech_Text.text = speech_Skill.ToString() + "/100";
            strength_Text.text = strength_Skill.ToString() + "/100";
            charisma_Text.text = charisma_Skill.ToString() + "/100";
            provocation_Text.text = provocation_Skill.ToString() + "/100";
            dexterity_Text.text = dexterity_Skill.ToString() + "/100";
            deadEye_Text.text = deadEye_Skill.ToString() + "/100";
        } 
    }
}
