using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddRuleButtonScript : MonoBehaviour
{
    GameObject button;
    public TextMeshProUGUI text;
    public TMP_InputField inputFieldPrefab; // Reference to your TMP_InputField prefab
    public Transform inputFieldParent; // Parent transform to place the new input field

    public static bool isActive = false;

    void Start()
    {
        button = gameObject;
    }

    public void ResetButton()
    {
        if (!isActive)
        {
            text.text = "";
            isActive = true;

            // Create and focus the input field
            CreateAndFocusInputField();
        }
        else
        {
            text.text = "";
            isActive = false;
            button.SetActive(false);
        }
    }

    void CreateAndFocusInputField()
    {
        if (inputFieldPrefab == null || inputFieldParent == null)
        {
            Debug.LogError("Input Field Prefab or Parent Transform not assigned.");
            return;
        }

        // Instantiate the input field prefab
        TMP_InputField inputFieldObject = Instantiate(inputFieldPrefab, inputFieldParent);

        // Set the input field as active
        inputFieldObject.gameObject.SetActive(true);

        // Ensure the input field is selected and focused
        StartCoroutine(ActivateInputFieldAfterDelay(inputFieldObject));
    }

    IEnumerator ActivateInputFieldAfterDelay(TMP_InputField inputField)
    {
        // Wait until the end of the frame to make sure the input field is fully instantiated
        yield return null;
        
        // Set focus to the input field and open the virtual keyboard
        inputField.ActivateInputField();
        inputField.Select();

        // For mobile devices, this will automatically open the keyboard
        // Optional: Force a delay to ensure the keyboard has time to open (adjust if necessary)
        yield return new WaitForSeconds(0.1f);

        // Ensure the TouchScreenKeyboard is opened for mobile devices
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false);
    }
}
