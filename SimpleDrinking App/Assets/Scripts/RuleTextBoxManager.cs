using UnityEngine;
using TMPro;

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
}

