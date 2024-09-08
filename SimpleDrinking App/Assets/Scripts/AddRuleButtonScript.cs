using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddRuleButtonScript : MonoBehaviour
{   
    GameObject button;
    public TextMeshProUGUI text;
    public static bool isActive = false;
    void Start() {
        button = gameObject;
    }
    public void ResetButton() {
        if(!isActive) {
            text.text = "";
            isActive = true;
        }
        else {
            text.text = "";
            isActive = false;
            button.gameObject.SetActive(false);
        }
    }
}
