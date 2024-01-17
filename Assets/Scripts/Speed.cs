using UnityEngine;
using TMPro;

public class Speed : MonoBehaviour
{
    public bool isSpeededUp = false;
    public TextMeshProUGUI buttonText; // Reference to the TextMeshProUGUI component of the button

    // Attach this function to the button's onClick event in the Unity Editor
    public void ToggleSpeed()
    {
        if (buttonText != null)
        {
            if (isSpeededUp)
            {
                // If already sped up, set the time scale back to normal (1x)
                Time.timeScale = 1f;
                buttonText.text = "1x"; // Update button text to indicate 1x speed
            }
            else
            {
                // If not sped up, set the time scale to 2x
                Time.timeScale = 2f;
                buttonText.text = "2x"; // Update button text to indicate 2x speed
            }

            // Toggle the flag
            isSpeededUp = !isSpeededUp;
        }
        else
        {
            Debug.LogError("Button TextMeshProUGUI component not assigned in the inspector.");
        }
    }
}