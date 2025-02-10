using UnityEngine;
using static ControlScript;

public class CharacterMovementScript : MonoBehaviour
{
    // Variables
    public GameObject playerCharacter;
    private ControlScript controlScript;
    float MouseSensitivity = 1f;
    float MoveSpeed = 0.0025f;
    float JumpForce = 1f;

    private void Start()
    {
        controlScript = GetComponent<ControlScript>();
        
    }

    void Update()
    {
        CharacterMovement();
    }

    void CharacterMovement()
    {
        if (Input.GetKey(controlScript.move_Up_Key))
        {
            playerCharacter.transform.Translate(0f, (1f * MoveSpeed), 0f);
        }
        if (Input.GetKey(controlScript.move_Down_Key))
        {
            playerCharacter.transform.Translate(0f, (-1f * MoveSpeed), 0f);
        }
        if (Input.GetKey(controlScript.move_Right_Key))
        {
            playerCharacter.transform.Translate((1f * MoveSpeed), 0f, 0f);
        }
        if (Input.GetKey(controlScript.move_Left_Key))
        {
            playerCharacter.transform.Translate((-1f * MoveSpeed), 0f, 0f);
        }
    }
}