using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class StartScreenController : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text playerListText;
    public Button addPlayerButton;
    public Button startButton;
    private List<string> playerNames = new List<string>();

    void Start()
    {
        inputField.onValueChanged.AddListener(HandleValueChanged);
        addPlayerButton.onClick.AddListener(HandleButtonSubmit);
        startButton.onClick.AddListener(StartGame);
    }

    private void HandleValueChanged(string input)
    {
        // Check for newline character (Enter key press)
        if (input.Contains("\n"))
        {
            // Remove the newline character
            input = input.Replace("\n", "");

            // Trim any leading or trailing whitespace from the input
            input = input.Trim();

            // Add player if the input is valid
            if (!string.IsNullOrEmpty(input))
            {
                AddPlayer(input);
                UpdatePlayerList();
                inputField.text = ""; // Clear the input field after adding
                inputField.ActivateInputField(); // Reactivate the input field for new input
            }
        }
    }

    private void HandleButtonSubmit()
    {
        string input = inputField.text;
        if (!string.IsNullOrEmpty(input))
        {
            AddPlayer(input);
            UpdatePlayerList();
            inputField.text = ""; // Clear the input field after adding
            inputField.ActivateInputField(); // Reactivate the input field for new input
        }
    }

    private void AddPlayer(string playerName)
    {
        playerNames.Add(playerName);
    }

    private void UpdatePlayerList()
    {
        playerListText.text = ""; // Clear the text first
        foreach (var name in playerNames)
        {
            playerListText.text += name + "\n"; // Append each player name with a newline
        }
    }

    public void StartGame()
    {
        if (playerNames.Count > 2)
        {
            PlayerLogic.InitiatePlayers(playerNames.Count);
            foreach (var playerName in playerNames)
            {
                PlayerLogic.AddPlayer(playerName);
            }

            Screen.orientation = ScreenOrientation.LandscapeLeft;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("At least 3 players are required to start the game.");
        }
    }
}
