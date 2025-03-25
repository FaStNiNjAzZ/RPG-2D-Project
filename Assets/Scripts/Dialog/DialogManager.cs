using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text dialogText;
    public Transform optionsContainer;
    public GameObject optionParentPrefab;
    public GameObject dialogPanel;
    public GameObject mainCanvasGroupUI;

    private List<GameObject> optionObjects = new List<GameObject>();
    public GameManager gameManager;

    private Stack<DialogNode> previousDialogs = new Stack<DialogNode>(); // Track previous dialogs
    private DialogNode currentDialog;

    private void Start()
    {
        HideDialogUI();
    }

    public void StartDialog(DialogNode dialog)
    {
        previousDialogs.Clear(); // Reset history when starting a new dialog
        ShowDialogUI();
        DisplayDialog(dialog);
    }

    public void DisplayDialog(DialogNode dialog)
    {
        if (currentDialog != null && dialog != currentDialog)
        {
            previousDialogs.Push(currentDialog); // Store the current dialog before changing
        }

        currentDialog = dialog; // Update the current dialog

        foreach (GameObject optionObject in optionObjects)
        {
            optionObject.SetActive(false);
        }

        dialogText.text = dialog.text;

        foreach (DialogOption option in dialog.options)
        {
            if (string.IsNullOrEmpty(option.requiredVariable) || gameManager.GetVariable(option.requiredVariable))
            {
                GameObject optionParent = GetOrCreateOptionParent();
                Button button = optionParent.GetComponentInChildren<Button>();
                TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();

                buttonText.text = option.optionText;

                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => OnOptionSelected(option));

                optionParent.SetActive(true);
            }
        }

        // ? Only show the Back button if `allowBack` is true
        if (previousDialogs.Count > 0 && currentDialog.allowBack)
        {
            GameObject backButtonParent = GetOrCreateOptionParent();
            Button backButton = backButtonParent.GetComponentInChildren<Button>();
            TMP_Text backButtonText = backButton.GetComponentInChildren<TMP_Text>();

            backButtonText.text = "Back";
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(GoBackToPreviousDialog);

            backButtonParent.SetActive(true);
        }

        // Create the Exit button
        GameObject exitParent = GetOrCreateOptionParent();
        Button exitButton = exitParent.GetComponentInChildren<Button>();
        TMP_Text exitButtonText = exitButton.GetComponentInChildren<TMP_Text>();

        exitButtonText.text = "Exit";
        exitButton.onClick.RemoveAllListeners();
        exitButton.onClick.AddListener(CloseDialog);

        exitParent.SetActive(true);
    }

    private void OnOptionSelected(DialogOption selectedOption)
    {
        if (selectedOption.repeatDialog)
        {
            DisplayDialog(currentDialog); // Re-display the same dialog
        }
        else if (selectedOption.nextDialog != null)
        {
            DisplayDialog(selectedOption.nextDialog);
        }
        else
        {
            CloseDialog();
        }
    }

    public void GoBackToPreviousDialog()
    {
        if (previousDialogs.Count > 0)
        {
            DialogNode previousDialog = previousDialogs.Pop(); // Get the last dialog
            DisplayDialog(previousDialog);
        }
    }

    public void CloseDialog()
    {
        HideDialogUI();
        previousDialogs.Clear();
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
        foreach (GameObject optionObject in optionObjects)
        {
            if (!optionObject.activeSelf)
            {
                return optionObject;
            }
        }

        GameObject newOptionParent = Instantiate(optionParentPrefab, optionsContainer);
        optionObjects.Add(newOptionParent);
        return newOptionParent;
    }
}
