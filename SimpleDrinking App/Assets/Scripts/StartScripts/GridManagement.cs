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

            // Ensure the Horizontal Layout Group handles the resizing
            // Optionally adjust the text component settings here

            // Ensure the button follows the text dynamically
            RectTransform textRectTransform = playerText.GetComponent<RectTransform>();
            RectTransform buttonRectTransform = removeButton.GetComponent<RectTransform>();

            // Make sure the button has a fixed size
            buttonRectTransform.sizeDelta = new Vector2(50, 50); // Adjust as needed

            // Make sure the text expands
            textRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, CalculateWidthBasedOnText(name));
            
            // Optionally, force an update of the layout group
            LayoutRebuilder.ForceRebuildLayoutImmediate(playerEntry.GetComponent<RectTransform>());
            
            // Set up the remove button to notify StartGameLogic when clicked
            removeButton.onClick.AddListener(() => RemovePlayer(name));
        }

        // Optionally adjust the grid layout after updating entries
        AdjustGridLayoutGroup();
    }

    private float CalculateWidthBasedOnText(string text)
    {
        TMP_Text tmpText = playerEntryPrefab.GetComponentInChildren<TMP_Text>();
        tmpText.text = text;
        return tmpText.preferredWidth;
    }

    private void RemovePlayer(string playerName)
    {
        // Notify StartGameLogic to remove the player from its list
        startGameLogic.RemovePlayer(playerName);
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
