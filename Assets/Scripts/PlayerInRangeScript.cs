using UnityEngine;
using UnityEngine.Rendering;

public class PlayerInRangeScript : MonoBehaviour
{
    /* 
    -- Tags --
    NPC_Talkable - Applied to NPCs that can be spoken to.

    Door_Mira_House_Exterior - Applied to Mira's outside door.
    Door_Mira_House_Interior - Applied to Mira's inside door.
    Door_Library_Exterior - Applied to Mira's outside door.
    Door_Library_Interior - Applied to Mira's inside door.

    Map_To_Library - For collecting map and enabling library location.
    */
    public GameObject press_E_Text_To_Talk;
    public GameObject press_E_Text_To_Enter;
    public GameObject press_E_Text_To_Pickup;
    bool isPlayerInRange;
    bool isPlayerInRangeOfDoor;
    bool isPlayerInRangeOfItem;
    public GameObject playerCharacter;
    public GameObject daxGroup;

    public GameObject libraryMapLocationGroup;
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("NPC_Talkable"))  // Ensure the tag is "Player" for the player GameObject
    //    {
    //        isPlayerInRange = true;
    //    }
    //}

    private void Start()
    {
        libraryMapLocationGroup.SetActive(false);

        press_E_Text_To_Talk.SetActive(false);
        press_E_Text_To_Enter.SetActive(false);
        press_E_Text_To_Pickup.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPC_Talkable"))  // Ensure the tag is "Player" for the player GameObject
        {
            isPlayerInRange = false;
        }

        if (other.CompareTag("Door_Mira_House_Exterior"))
        {
            isPlayerInRangeOfDoor = false;
        }

        if (other.CompareTag("Door_Mira_House_Interior"))
        {
            isPlayerInRangeOfDoor = false;
        }

        if (other.CompareTag("Map_To_Library"))
        {
            isPlayerInRangeOfDoor = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("NPC_Talkable"))  // Ensure the tag is "Player" for the player GameObject
        {
            isPlayerInRange = true;
        }

        if (other.CompareTag("Door_Mira_House_Exterior"))
        {
            
            isPlayerInRangeOfDoor = true;
            if (Input.GetKey(KeyCode.E))
            {
                playerCharacter.transform.position = new Vector3(-3500, -3000, 0);
            }
        }

        if (other.CompareTag("Door_Mira_House_Interior"))
        {
            Debug.Log("In range of door");
            isPlayerInRangeOfDoor = true;
            if (Input.GetKey(KeyCode.E))
            {
                playerCharacter.transform.position = new Vector3(-3000, -3000, 0);
            }
        }

        if (other.CompareTag("Door_Library_Exterior"))
        {

            isPlayerInRangeOfDoor = true;
            if (Input.GetKey(KeyCode.E))
            {
                playerCharacter.transform.position = new Vector3(-2500, -2000, 0);
            }
        }

        if (other.CompareTag("Door_Library_Interior"))
        {
            Debug.Log("In range of door");
            isPlayerInRangeOfDoor = true;
            if (Input.GetKey(KeyCode.E))
            {
                playerCharacter.transform.position = new Vector3(-2000, -2000, 0);
            }
        }

        if (other.CompareTag("Map_To_Library"))
        {
            isPlayerInRangeOfItem = true;
            if (Input.GetKey(KeyCode.E))
            {
                libraryMapLocationGroup.SetActive(true);
            }
        }
    }

    private void Update()
    {
        if (isPlayerInRange) { press_E_Text_To_Talk.SetActive(true); }
        else if (!isPlayerInRange) { press_E_Text_To_Talk.SetActive(false); }

        if (isPlayerInRangeOfDoor) { press_E_Text_To_Enter.SetActive(true); }
        else if (!isPlayerInRangeOfDoor) { press_E_Text_To_Enter.SetActive(false); }

        if (isPlayerInRangeOfItem) { press_E_Text_To_Pickup.SetActive(true); }
        else if (!isPlayerInRangeOfItem) { press_E_Text_To_Pickup.SetActive(false); }
    }

}
