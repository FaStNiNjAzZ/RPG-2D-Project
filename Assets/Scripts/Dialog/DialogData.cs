using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogNode
{
    public string text; // The dialog text to display
    public List<DialogOption> options; // List of options for this dialog node
    public bool allowBack; // Toggle to enable or disable the back button
}

[System.Serializable]
public class DialogOption
{
    public string optionText; // Text for this dialog option
    public DialogNode nextDialog; // The next dialog node to display when selected
    public string requiredVariable; // Variable required to show this option
    public bool repeatDialog; // If true, selecting this option will repeat the current dialog


}

public class DialogData : MonoBehaviour
{
    public DialogNode npc1Start = new DialogNode
    {
        text = "Hello, traveler! How can I help you?",
        allowBack = false, // ❌ Back is disabled in this node
        options = new List<DialogOption>
        {
            new DialogOption
            {
                optionText = "What do you sell?",
                nextDialog = new DialogNode
                {
                    text = "I sell potions and rare artifacts. Interested?",
                    allowBack = true, // ✅ Back is enabled in this node
                    options = new List<DialogOption>
                    {
                        new DialogOption { optionText = "Show me your wares.", nextDialog = null },
                        new DialogOption { optionText = "Maybe later.", nextDialog = null }
                    }
                }
            },
            new DialogOption
            {
                optionText = "Ask again (Repeat)",
                nextDialog = null,
                repeatDialog = true
            },
            new DialogOption
            {
                optionText = "Nothing, just passing through.",
                nextDialog = new DialogNode
                {
                    text = "Safe travels, friend!",
                    allowBack = false, // ❌ Back is disabled in this node
                    options = new List<DialogOption>()
                }
            }
        }
    };
}

