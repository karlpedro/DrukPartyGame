using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Make sure to include this if you're working with InputField

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

        // Set the input field as active and focus it
        inputFieldObject.gameObject.SetActive(true);
        inputFieldObject.ActivateInputField();
        inputFieldObject.Select(); // Optionally set the focus on the input field
    }
}
