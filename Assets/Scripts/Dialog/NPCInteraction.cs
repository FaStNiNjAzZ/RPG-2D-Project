using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public DialogManager dialogManager;  // Reference to the dialog manager


    public DialogNode npcDialog;         // The specific dialog node for this NPC

    private bool isPlayerInRange = false;
    public float interactionRange = 3f;  // Range for interaction
    public KeyCode interactKey = KeyCode.E;  // Key to interact

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(interactKey))
        {
            // Call the DialogManager to start dialog with this NPC's dialog node
            dialogManager.StartDialog(npcDialog);
        }
    }

    // Called when the player enters the trigger collider (2D version)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Ensure the tag is "Player" for the player GameObject
        {
            isPlayerInRange = true;  // Player is in range
            Debug.Log("Player is in range of NPC!");
        }
    }

    // Called when the player exits the trigger collider (2D version)
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Ensure the tag is "Player" for the player GameObject
        {
            isPlayerInRange = false;  // Player leaves range
            Debug.Log("Player is out of range of NPC!");
        }
    }
}