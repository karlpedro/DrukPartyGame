using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class GridManagement : MonoBehaviour
{
    public GridLayoutGroup gridLayoutGroup;
    public GameObject playerEntryPrefab;
    public Transform playerListContainer;
    public StartGameLogic startGameLogic;

    // This method will be called by StartGameLogic to update the UI
    public void UpdatePlayerList(List<string> playerNames)
    {
        // Clear existing entries in the grid
        foreach (Transform child in playerListContainer)
        {
            Destroy(child.gameObject);
        }

        // Add new entries based on the playerNames list passed from StartGameLogic
        foreach (var name in playerNames)
        {
            GameObject playerEntry = Instantiate(playerEntryPrefab, playerListContainer);
            TMP_Text playerText = playerEntry.GetComponentInChildren<TMP_Text>();
            Button removeButton = playerEntry.GetComponentInChildren<Button>();

            playerText.text = name;

            // Adjust the size of the entry dynamically
            LayoutElement layoutElement = playerEntry.GetComponent<LayoutElement>();
            if (layoutElement != null)
            {
                layoutElement.preferredWidth = CalculateWidthBasedOnText(name);
                layoutElement.preferredHeight = 50; // Set a fixed height
            }

            // Set up the remove button to notify StartGameLogic when clicked
            removeButton.onClick.AddListener(() => RemovePlayer(name));
        }

        // Optionally adjust the grid layout after updating entries
        AdjustGridLayoutGroup();
    }

    // This method notifies StartGameLogic to remove the player from its list
    private void RemovePlayer(string playerName)
    {
        // Notify StartGameLogic to remove the player from its list
        startGameLogic.RemovePlayer(playerName);
    }

    private float CalculateWidthBasedOnText(string text)
    {
        // Adjust the width based on the length of the text
        TMP_Text tmpText = playerEntryPrefab.GetComponentInChildren<TMP_Text>();
        tmpText.text = text;
        return tmpText.preferredWidth;
    }

    private void AdjustGridLayoutGroup()
    {
        // Optionally adjust the GridLayoutGroup settings if needed
        if (gridLayoutGroup != null)
        {
            gridLayoutGroup.cellSize = new Vector2(100, 50); // Adjust size based on your needs
        }
    }
}
