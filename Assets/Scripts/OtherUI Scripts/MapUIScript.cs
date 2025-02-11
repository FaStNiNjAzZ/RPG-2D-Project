using UnityEngine;

public class MapUIScript : MonoBehaviour
{
    // Locations:
    // The Hollow (Player Village and starting location) CORD: -1000, -1000
    // New Pine (Town) CORD: -2000, -2000
    // Rust Town (Town) CORD: -3000, -3000
    // The Airstrip CORD: 2000, 2000
    // The Bunker (The Ascendent Order basse and final location) CORD: 1000, 1000

    // Random Locations:
    // Raiding Outpost CORD: 5000, -5000


    // Test Location CORD: 25000, 25000

    public GameObject playerCharacter;
    public GameObject map_UI;

    public void Location_Selector(int selector)
    {
        switch (selector)
        {
            case 0: // The Hollow
                playerCharacter.transform.position = new Vector3(-1000, -1000, 0);
                break;
            case 1: // New Pine
                playerCharacter.transform.position = new Vector3(-2000, -2000, 0);
                break;
            case 2: // Rust Town
                playerCharacter.transform.position = new Vector3(-3000, -3000, 0);
                break;
            case 3: // The Airstrip
                playerCharacter.transform.position = new Vector3(2000, 2000, 0);
                break;
            case 31: // The Bunker
                playerCharacter.transform.position = new Vector3(1000, 1000, 0);
                break;
            case 9: // The Airstrip
                playerCharacter.transform.position = new Vector3(5000, -5000, 0);
                break;

        }
    }

    public void Map_Control(int selector)
    {
        switch (selector)
        {
            case 0:
                map_UI.SetActive(true); 
                break;
            case 1:
                map_UI.SetActive(false);
                break;
        }
    }

}
