using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text dialogText; // UI text for dialog
    public Transform optionsContainer; // Container for option buttons
    public GameObject optionParentPrefab; // Prefab with a parent GameObject and button
    public GameObject dialogPanel; // Dialog UI panel
    public GameObject mainCanvasGroupUI;

    private List<GameObject> optionObjects = new List<GameObject>(); // Store created options for re-use

    private void Start()
    {
        // Ensure dialog is hidden at the start
        HideDialogUI();
    }

    public void StartDialog(DialogNode dialog)
    {
        ShowDialogUI();
        DisplayDialog(dialog);
    }

    public void DisplayDialog(DialogNode dialog)
    {
        // Deactivate any existing options
        foreach (GameObject optionObject in optionObjects)
        {
            optionObject.SetActive(false);
        }

        // Set the dialog text
        dialogText.text = dialog.text;

        // Create or activate buttons for each dialog option
        foreach (DialogOption option in dialog.options)
        {
            GameObject optionParent = GetOrCreateOptionParent();
            Button button = optionParent.GetComponentInChildren<Button>();
            TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();

            buttonText.text = option.optionText;

            // Clear existing listeners and add a new one
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => OnOptionSelected(option));

            optionParent.SetActive(true); // Activate the button
        }

        // Create or activate the Exit button
        GameObject exitParent = GetOrCreateOptionParent();
        Button exitButton = exitParent.GetComponentInChildren<Button>();
        TMP_Text exitButtonText = exitButton.GetComponentInChildren<TMP_Text>();

        exitButtonText.text = "Exit";

        // Clear existing listeners and add a new one
        exitButton.onClick.RemoveAllListeners();
        exitButton.onClick.AddListener(CloseDialog);

        exitParent.SetActive(true); // Activate the exit button
    }

    private void OnOptionSelected(DialogOption selectedOption)
    {
        if (selectedOption.nextDialog != null)
        {
            // Display the next dialog node
            DisplayDialog(selectedOption.nextDialog);
        }
        else
        {
            // Close dialog if no further options exist
            CloseDialog();
        }
    }

    public void CloseDialog()
    {
        HideDialogUI();

        // Deactivate all option buttons for reuse
        foreach (GameObject optionObject in optionObjects)
        {
            optionObject.SetActive(false);
        }
    }

    private void ShowDialogUI()
    {
        dialogPanel.SetActive(true);
        dialogText.gameObject.SetActive(true);
        optionsContainer.gameObject.SetActive(true);

        mainCanvasGroupUI.SetActive(false);
    }

    private void HideDialogUI()
    {
        dialogPanel.SetActive(false);
        dialogText.gameObject.SetActive(false);
        optionsContainer.gameObject.SetActive(false);

        mainCanvasGroupUI.SetActive(true);
    }

    private GameObject GetOrCreateOptionParent()
    {
        // Try to find an existing deactivated option
        foreach (GameObject optionObject in optionObjects)
        {
            if (!optionObject.activeSelf)
            {
                return optionObject; // Reuse an existing deactivated option
            }
        }

        // If none are available, create a new one
        GameObject newOptionParent = Instantiate(optionParentPrefab, optionsContainer);
        optionObjects.Add(newOptionParent);
        return newOptionParent;
    }
}