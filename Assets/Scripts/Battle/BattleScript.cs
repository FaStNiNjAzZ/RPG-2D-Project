using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour
{
    public GameObject main_Camera;
    public GameObject arena_Camera;

    public GameObject player_Character;
    public GameObject enemy_Character1;
    public GameObject enemy_Character2;
    public GameObject enemy_Character3;

    Vector2 arena_Location_Center = new Vector2(-200f, 200f);
    Vector2 player_Position_Of_Origin;

    SkillScript skillScript;

    private void Start()
    {
        skillScript = GetComponent<SkillScript>();
    }
    void StartBattle()
    {
        main_Camera.SetActive(false);
        arena_Camera.SetActive(true);

        player_Position_Of_Origin = Find_Game_Object_Position(player_Character);
        player_Character.transform.position = new Vector2 (arena_Location_Center.x, arena_Location_Center.y);
    }

    void End_Battle()
    {
        main_Camera.SetActive(true);
        arena_Camera.SetActive(false);

        player_Character.transform.position = player_Position_Of_Origin;
    }

    Vector2 Find_Game_Object_Position(GameObject target_Object)
    {
        if (target_Object != null)
        {
            float xPosition = target_Object.transform.position.x;
            float yPosition = target_Object.transform.position.y;

            return new Vector2(xPosition, yPosition);
        }
        else
        {
            Debug.Log("Target object is not assigned!");
            return Vector2.zero; // Return (0, 0) if the object is not assigned
        }
    }

}
