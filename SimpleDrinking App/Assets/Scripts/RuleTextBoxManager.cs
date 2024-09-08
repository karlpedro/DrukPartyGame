using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class RuleTextBoxManager : MonoBehaviour
{
    public TMP_InputField inputFieldPrefab; // Reference to the TMP InputField prefab
    public Transform inputFieldParent; // Parent object to hold the InputFields

    private TMP_InputField currentInputField; // Reference to the currently instantiated input field
    public TextMeshProUGUI textOutPut;
    public GameObject overlay;
    
    void Start() {
        textOutPut.text = null;
        textOutPut.gameObject.SetActive(false);
    }

    public void CreateInputField()
    {   
        if(!AddRuleButtonScript.isActive) {
            if (currentInputField == null) {
                currentInputField = Instantiate(inputFieldPrefab, inputFieldParent);

                Vector3 newPosition = inputFieldParent.position;
                newPosition.y += 250f; 
                currentInputField.transform.position = newPosition;
                StartCoroutine(ActivateInputFieldAfterDelay(currentInputField));
            }
        }
        else if (!string.IsNullOrEmpty(currentInputField.text)){   
            textOutPut.text = currentInputField.text;
            textOutPut.gameObject.SetActive(true);
            Destroy(currentInputField.gameObject);
            overlay.gameObject.SetActive(false);
        }
    }

    public void ResetTextOutPut() {
        textOutPut.text = null;
        ResetTextOutPut();
    }

    IEnumerator ActivateInputFieldAfterDelay(TMP_InputField inputField)
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
}

