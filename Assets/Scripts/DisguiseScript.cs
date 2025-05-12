using Unity.VisualScripting;
using UnityEngine;

public class DisguiseScript : MonoBehaviour
{
    // Variables
    bool pick_Up_Disguise = false;
    bool is_Player_In_Range;
    bool is_Player_In_Range_Of_Scientist;
    bool is_Player_In_Range_Of_Map;
    bool is_Player_In_Range_Of_Dax_Crowne_Group;
    bool is_Player_In_Range_Of_Computer_Module;
    const KeyCode INTERACT_KEY = KeyCode.E;

    // Game Objects
    public GameObject disguise_Clothing_Game_Object;
    public GameObject map_To_Library_World_Object;
    public GameObject disguise_Clothing_World_Object;
    public GameObject rust_Town_NPC_Group_Game_Object;
    public GameObject rust_Town_NPC_Original_Group_Game_Object;
    public GameObject dax_Crowne_Group_Game_Object;

    // UI Game Objects
    public GameObject map_Airstrip_Button_Group;
    public GameObject map_New_Pine_Button_Group;
    public GameObject map_Button_Group;

    private void Start()
    {
        map_Airstrip_Button_Group.SetActive(false);
        disguise_Clothing_World_Object.SetActive(false);
        map_New_Pine_Button_Group.SetActive(false);
        map_To_Library_World_Object.SetActive(true);

        rust_Town_NPC_Original_Group_Game_Object.SetActive(true);
        rust_Town_NPC_Group_Game_Object.SetActive(false);
        dax_Crowne_Group_Game_Object.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player_Disguise_Object"))  // Ensure the tag is "Player" for the player GameObject
        {
            is_Player_In_Range = true;  // Player is in range
        }
        
        if (other.CompareTag("Trigger_Disguise_Spawn_Scientist"))
        {
            Debug.Log("Disguise_Clothing_World_Object in range");
            is_Player_In_Range_Of_Scientist = true;

        }

        if (other.CompareTag("Map_To_Library"))
        {
            Debug.Log("Disguise_Clothing_World_Object in range");
            is_Player_In_Range_Of_Map = true;

        }

        if (other.CompareTag("Dax_Crowne_Group_Tag"))
        {
            is_Player_In_Range_Of_Dax_Crowne_Group = true;

        }

        if (other.CompareTag("Computer_Module_Library"))
        {
            is_Player_In_Range_Of_Computer_Module = true;
        }
    }

    // Called when the player exits the trigger collider (2D version)
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player_Disguise_Object"))  // Ensure the tag is "Player" for the player GameObject
        {
            is_Player_In_Range = false;  // Player leaves range
        }

        if (other.CompareTag("Trigger_Disguise_Spawn_Scientist"))
        {
            is_Player_In_Range_Of_Scientist = false;
        }

        if (other.CompareTag("Map_To_Library"))
        {
            is_Player_In_Range_Of_Map = false;
        }

        if (other.CompareTag("Dax_Crowne_Group_Tag"))
        {
            is_Player_In_Range_Of_Dax_Crowne_Group = false;
        }

        if (other.CompareTag("Computer_Module_Library"))
        {
            is_Player_In_Range_Of_Computer_Module = false;
        }
    }

    private void Update()
    {
        if (is_Player_In_Range && Input.GetKeyDown(INTERACT_KEY))
        {
            pick_Up_Disguise = true;
            map_Airstrip_Button_Group.SetActive(true);
            disguise_Clothing_World_Object.SetActive(false);
        }

        if (is_Player_In_Range_Of_Scientist && Input.GetKeyDown(INTERACT_KEY))
        {
            disguise_Clothing_World_Object.SetActive(true);
            dax_Crowne_Group_Game_Object.SetActive(false);
            Debug.Log("Toggle disguise_Clothing_World_Object to true");
        }

        if (is_Player_In_Range_Of_Map && Input.GetKeyDown(INTERACT_KEY))
        {
            pick_Up_Disguise = true;
            map_New_Pine_Button_Group.SetActive(true);
            map_To_Library_World_Object.SetActive(false);
        }

        if (is_Player_In_Range_Of_Dax_Crowne_Group && Input.GetKeyDown(INTERACT_KEY))
        {
            rust_Town_NPC_Group_Game_Object.SetActive(true);
            rust_Town_NPC_Original_Group_Game_Object.SetActive(false);
            map_Button_Group.SetActive(true);
        }

        if (is_Player_In_Range_Of_Computer_Module && Input.GetKeyDown(INTERACT_KEY))
        {
            map_Button_Group.SetActive(false);
            dax_Crowne_Group_Game_Object.SetActive(true);
        }
    }
}
