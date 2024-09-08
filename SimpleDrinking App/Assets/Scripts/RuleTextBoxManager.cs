using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RuleTextBoxManager : MonoBehaviour
{
    public TMP_InputField inputFieldPrefab; // Reference to the TMP InputField prefab
    public Transform inputFieldParent; // Parent object to hold the InputFields

    private TMP_InputField currentInputField; // Reference to the currently instantiated input field
    public TextMeshProUGUI textOutPut;
    public GameObject overlay;
    public GameObject button;

    private bool isActive = false; // Track if the input field is active

    void Start()
    {
        textOutPut.text = null;
        textOutPut.gameObject.SetActive(false);
        overlay.gameObject.SetActive(false);
        button.SetActive(false);
    }

    public void ToggleInputField()
    {
        if (!isActive)
        {
            CreateInputField();
        }
        else if (currentInputField != null && !string.IsNullOrEmpty(currentInputField.text))
        {
            submitInputField(currentInputField.text);
        }
    }

    private void CreateInputField()
    {
        if (currentInputField == null)
        {
            currentInputField = Instantiate(inputFieldPrefab, inputFieldParent);

            Vector3 newPosition = inputFieldParent.position;
            newPosition.y += 250f;
            currentInputField.transform.position = newPosition;

            StartCoroutine(ActivateInputFieldAfterDelay(currentInputField));

            currentInputField.onValueChanged.AddListener(OnInputFieldValueChanged);
            currentInputField.onEndEdit.AddListener(OnInputFieldEndEdit);

            isActive = true; // Mark the input field as active
            button.SetActive(true);
        }
    }

    private void submitInputField(string text)
    {
        textOutPut.text = text;
        textOutPut.gameObject.SetActive(true);
        Destroy(currentInputField.gameObject);
        overlay.gameObject.SetActive(false);
        isActive = false; // Mark the input field as inactive
        button.SetActive(false);
        currentInputField = null; // Reset reference
    }

    public void ResetTextOutPut()
    {
        textOutPut.text = null;
        // Any other reset logic if needed
    }

    private IEnumerator ActivateInputFieldAfterDelay(TMP_InputField inputField)
    {
        // Wait until the end of the frame to make sure the input field is fully instantiated
        yield return null;

        // Set focus to the input field and open the virtual keyboard
        inputField.ActivateInputField();
        inputField.Select();

        // Optional: Force a delay to ensure the keyboard has time to open (adjust if necessary)
        yield return new WaitForSeconds(0.1f);

        // Ensure the TouchScreenKeyboard is opened for mobile devices
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false);
    }

    private void OnInputFieldValueChanged(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return;
        }
        if (input.Contains("\n") || input.Contains("\r"))
        {
            // Replace newline characters with nothing and process
            string processedInput = input.Replace("\r", "").Replace("\n", "").Trim();
            submitInputField(processedInput);
        }
    }

    private void OnInputFieldEndEdit(string input)
    {
        if (!string.IsNullOrEmpty(input))
        {
            submitInputField(input.Trim());
        }
    }
}
