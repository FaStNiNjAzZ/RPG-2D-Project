using UnityEngine;
using TMPro;

public class RaycastInteractionSelection : MonoBehaviour
{
    public const float INTERACTION_DISTANCE = 3f;
    public LayerMask npc_Layer_Mask;

    public Camera player_Camera;
    public const KeyCode INTERACT_KEY = KeyCode.E;

    public GameObject interaction_UI_Group;
    public TMP_Text interaction_UI_Text_TMP;

    private void Start()
    {
        interaction_UI_Group.SetActive(false);
    }

    private void Update()
    {
        NPC_Interaction_Check();
    }

    private void NPC_Interaction_Check()
    {
        Ray ray = new Ray(player_Camera.transform.position, player_Camera.transform.forward);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, INTERACTION_DISTANCE, npc_Layer_Mask))
        {
            NPC npc = hit.collider.GetComponent<NPC>();
            if (npc != null)
            {
                Debug.Log("Interacting with " + npc.name);
                interaction_UI_Group.SetActive(true);
                interaction_UI_Text_TMP.text = ("[" + INTERACT_KEY + "] Talk To\n" + npc.name);

                if (Input.GetKeyDown(INTERACT_KEY))
                {
                   // npc.Interact();
                }
            }
            
        }
        else
        {
            interaction_UI_Group.SetActive(false);
        }
    }



}
