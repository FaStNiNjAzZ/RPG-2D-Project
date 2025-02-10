using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DynamicButtons : MonoBehaviour
{
    public GameObject dialogButtonPrefab;
    public GameObject dialogButtonParent;

    private void Start()
    {

        string[] dialogExample = { "This is Text 1", "this is test 2", "This is a very long text test, I think this works quite well but we will see.", "this is another test."};
        ButtonCreation(4, dialogExample);
    }

    // TODO -- Only make the buttons return integers depending on what button is press (e.g. button 0 will only return 0 when clicked).
    void ButtonCreation(int buttonCount, string[] buttonDialogText) 
    {
        for (int i = 0; i < buttonCount; i++)
        {
            GameObject newDialogButton = Instantiate(dialogButtonPrefab, dialogButtonParent.transform);
            newDialogButton.GetComponentInChildren<TMP_Text>().text = buttonDialogText[i];
        }
    }

    private void DialogSelector()
    {
        Debug.Log("Working");
    }

    void DialogButtonActivate(int dialogOptionButtonSelected)
    {

    }
}
