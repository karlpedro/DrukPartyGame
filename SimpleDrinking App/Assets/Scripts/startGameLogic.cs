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
        addPlayerButton.onClick.AddListener(HandleButtonSubmit);
        startButton.onClick.AddListener(StartGame);
    }

    private void HandleButtonSubmit()
    {
        string input = inputField.text;
        if (!string.IsNullOrEmpty(input))
        {
            AddPlayer(input);
            inputField.text = ""; // Clear the input field after adding
            inputField.ActivateInputField(); // Reactivate the input field for new input
        }
    }

    private void AddPlayer(string playerName)
    {
        playerNames.Add(playerName);
        UpdatePlayerList();
    }

    private void UpdatePlayerList()
    {
        playerListText.text = string.Join("\n", playerNames);
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
