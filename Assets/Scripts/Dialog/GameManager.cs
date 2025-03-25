using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Dictionary<string, bool> playerVariables = new Dictionary<string, bool>();

    // Set a variable (e.g., the player has completed a task)
    public void SetVariable(string variableName, bool value)
    {
        if (playerVariables.ContainsKey(variableName))
        {
            playerVariables[variableName] = value;
        }
        else
        {
            playerVariables.Add(variableName, value);
        }
    }

    // Get a variable (e.g., whether the player has completed a task)
    public bool GetVariable(string variableName)
    {
        return playerVariables.ContainsKey(variableName) && playerVariables[variableName];
    }
}