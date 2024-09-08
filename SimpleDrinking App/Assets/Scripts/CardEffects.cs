using UnityEngine;
using TMPro;

public class CardEffects : MonoBehaviour
{
    public TextMeshProUGUI kingText; // Reference to the king UI element
    private string tempKingText;
    public static bool isKing = false; // Flag to track if a player is the king
    private int kingRounds = 0; // Number of rounds the player remains the king

    public TextMeshProUGUI tramandText; // Reference to the king UI element
    private int tramandRounds = 0;
    public static bool isTramand = false;
    private string tempTramandText;
    public OverLayScript overlayScript;
    private Player player;
    public static Player king;
    public static Player tramand;
    public GameObject ruleButton;

    public GameObject kingPrefab;
    
    public void ApplyEffect(CardEffectType effectType, string extraString) {
        player = PlayerLogic.getPlayerWithName(extraString);
        switch (effectType)
        {   
            case CardEffectType.BecomeKing:
                BecomeKing(extraString);
                break;
            case CardEffectType.LoseKing:
                LoseKing();
                break;
            case CardEffectType.BecomeTramand:
                BecomeTramand(extraString);
                break;
            case CardEffectType.MakeRule:
                MakeRule(extraString);
                break;
            case CardEffectType.None:
                break;
            case CardEffectType.Reset:
                ResetCardEffects();
                break;
            default:
                break;
        }
        UpdateStatus();
    }

    private void MakeRule(string playerName) {
        overlayScript.SetAddRulesActive(playerName);
        ruleButton.gameObject.SetActive(true);
    }

    private void BecomeTramand(string playerName) {

        player.IsMmand(true);
        tramand = player;
        tramandText.text = "TRÆMAND: "+playerName;
        tempTramandText = "TRÆMAND: "+playerName;
        tramandText.gameObject.SetActive(true);
        isTramand = true;
        tramandRounds = 21; //rounds -1
    }

    private void LoseTramand() {
        overlayScript.SetLosingMand(tramand);
        tramandText.gameObject.SetActive(false);
        tramand.IsMmand(false);
        tramand = null;
        tramandText.text = "";
        isTramand = false;
        tramandRounds = 0;
        overlayScript.setActive();
    }

    private void BecomeKing(string playerName) {   
        player.IsKing(true);
        king = player;
        kingText.text = playerName; //UI Display text
        tempKingText = playerName; //Storing text for updating roundNumbers
        kingPrefab.SetActive(true);
        isKing = true;
        kingRounds = 21; //rounds -1
    }

    private void LoseKing() {
        overlayScript.SetLosingKing(king);
        kingPrefab.SetActive(false);
        king.IsKing(false);
        king = null;
        kingText.text = "";
        isKing = false;
        kingRounds = 0;
        overlayScript.setActive();
    }

    public void UpdateStatus() {
        if (isKing && kingRounds > 0) {
            kingRounds--;
            string newText = tempKingText;
            newText += " "+kingRounds;
            kingText.text = newText;
            if (kingRounds == 0) {
                kingText.text = "NO LONGER KING";
                LoseKing();
            }
        }
        if (isTramand && tramandRounds >0) {
            tramandRounds--;
            string newText = tempTramandText;
            newText += " "+tramandRounds;
            tramandText.text = newText;
            if (tramandRounds == 0) {
                tramandText.text = "NO LONGER TRÆMAND";
                LoseTramand();
            }
        }
    }

    public void ResetCardEffects()
    {
        // Reset King and Træmand statuses
        if (isKing)
        {
            LoseKing(); // Properly handle losing King status
        }
        
        if (isTramand)
        {
            LoseTramand(); // Properly handle losing Træmand status
        }

        // Reset UI elements and internal variables
        kingText.text = "";
        tramandText.text = "";
        isKing = false;
        isTramand = false;
        kingRounds = 0;
        tramandRounds = 0;

        kingPrefab.SetActive(false);
        ruleButton.SetActive(false);
    }

}
