using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class ButtonTextColour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    // Variables
    public TMP_Text buttonText;
    public Color normalColour, hoverColour, clickColour;

    // Use Awake to load before the scene starts. 
    private void Awake()
    {
        // Get TMP_Text Component from children. This use case would be for the button.
        buttonText = GetComponentInChildren<TMP_Text>();

        // If not found, log an error
        if (buttonText == null)
        {
            Debug.LogError("Error: Missing TMP_Text in: " + gameObject.name);
        }

        // Set colours with Hex
        ColorUtility.TryParseHtmlString("#e6e6b9", out normalColour); // Yellow
        ColorUtility.TryParseHtmlString("#dfdf97", out hoverColour);  // Dark Yellow
        ColorUtility.TryParseHtmlString("#ffffff", out clickColour);  // White

        buttonText.color = normalColour; // Set Color to Default for consistency 
    }


    // Functions
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = hoverColour; // Change text color on hover
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = normalColour; // Reset color when mouse exits
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonText.color = clickColour; // Change text color when clicked
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonText.color = hoverColour; // Change back to hover color when released
    }
}