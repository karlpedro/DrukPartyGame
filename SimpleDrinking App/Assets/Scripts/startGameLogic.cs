using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using TMPro.Examples;

public class StartScreenController : MonoBehaviour
{
    public TMP_InputField inputField1, inputField2, inputField3, inputField4, inputField5,
    inputField6, inputField7, inputField8, inputField9, inputField10;
    private int numberOfInputFields = 10;
    int numberOfNames = 0;
            private TMP_InputField[] allFields;

    // Method to be called when the Start Button is pressed
    public void StartGame()
    {   
        SetupTextFields();
        SetupPlayers();
        if(numberOfNames>2) {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );
        }
    }

    private void SetupPlayers() {
        for(var i=0; i < numberOfInputFields; i++) {
            string playerName = allFields[i].text;
            if(playerName.Length!=0) {
                numberOfNames++;
            }
        }
        PlayerLogic.InitiatePlayers(numberOfNames);
        for(var i=0; i < numberOfInputFields; i++) {
            string playerName = allFields[i].text;
            if(playerName.Length!=0) {
                PlayerLogic.AddPlayer(playerName);
            }
        }
    }

    private void SetupTextFields() {
        allFields = new TMP_InputField[numberOfInputFields];
    
        allFields[0] = inputField1;
        allFields[1] = inputField2;
        allFields[2] = inputField3;
        allFields[3] = inputField4;
        allFields[4] = inputField5;
        allFields[5] = inputField6;
        allFields[6] = inputField7;
        allFields[7] = inputField8;
        allFields[8] = inputField9;
        allFields[9] = inputField10;
    }
}
