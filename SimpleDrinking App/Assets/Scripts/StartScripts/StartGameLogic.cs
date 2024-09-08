using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class StartGameLogic : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button addPlayerButton;
    public Button startButton;
    public GridManagement gridManagement;

    private List<string> playerNames = new List<string>();

    void Start()
    {
        addPlayerButton.onClick.AddListener(HandleButtonSubmit);
        startButton.onClick.AddListener(StartGame);
        inputField.onEndEdit.AddListener(OnInputFieldEndEdit); // Add listener for the input field
        Screen.orientation = ScreenOrientation.Portrait;

        // Make sure GridManagement has reference to this logic for removal purposes
        gridManagement.startGameLogic = this;
    }

    private void OnInputFieldEndEdit(string input)
    {
        if (!string.IsNullOrEmpty(input))
        {
            HandleButtonSubmit();
        }
    }


    private void HandleButtonSubmit()
    {
        string input = inputField.text;
        if (!string.IsNullOrEmpty(input))
        {
            AddPlayer(input);
            UpdatePlayerListUI();
            inputField.text = ""; // Clear the input field after adding
            inputField.ActivateInputField(); // Reactivate the input field for new input
        }
    }

    private void AddPlayer(string playerName)
    {
        // Avoid adding duplicate names
        if (!playerNames.Contains(playerName))
        {
            playerNames.Add(playerName);
        }
    }

    public void RemovePlayer(string playerName)
    {
        // Remove player from the internal list
        if (playerNames.Contains(playerName))
        {
            playerNames.Remove(playerName);
        }

        // Update the UI after removing the player
        UpdatePlayerListUI();
    }

    // This method is responsible for updating the grid UI
    private void UpdatePlayerListUI()
    {
        // Notify GridManagement to update the UI
        gridManagement.UpdatePlayerList(playerNames);
    }

    public void StartGame()
    {
        // Ensure enough players are added before starting
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
