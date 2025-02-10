using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogNode
{
    public string text; // The dialog text to display
    public List<DialogOption> options; // List of options for this dialog node
}

[System.Serializable]
public class DialogOption
{
    public string optionText; // Text for this dialog option
    public DialogNode nextDialog; // The next dialog node to display when selected
}
public class DialogData : MonoBehaviour
{
    public DialogNode npc1Start = new DialogNode
    {
        text = "Hello, traveler! How can I help you?",
        options = new List<DialogOption>
        {
            new DialogOption
            {
                optionText = "What do you sell?",
                nextDialog = new DialogNode
                {
                    text = "I sell potions and rare artifacts. Interested?",
                    options = new List<DialogOption>
                    {
                        new DialogOption { optionText = "Show me your wares.", nextDialog = null },
                        new DialogOption { optionText = "Maybe later.", nextDialog = null }
                    }
                }
            },
            new DialogOption
            {
                optionText = "Nothing, just passing through.",
                nextDialog = new DialogNode
                {
                    text = "Safe travels, friend!",
                    options = new List<DialogOption>()
                }
            }
        }
    };
}