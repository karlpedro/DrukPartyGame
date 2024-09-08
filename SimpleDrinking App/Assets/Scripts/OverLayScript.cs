using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OverLayScript : MonoBehaviour
{
    public GameObject overlay;
    public TextMeshProUGUI text = null;
    public CardEffects cEffect;

    public static bool overLayIsActive = false;
    public TextMeshProUGUI maintext;

    public CanvasGroup overlayCanvasGroup;

    void Start() {
        text.text = null;
    }

    public void setActive() {
        overLayIsActive = true;
        overlay.gameObject.SetActive(true);
        overlayCanvasGroup.blocksRaycasts = true;
    }

    public void setNotActive() {
        overLayIsActive = false;
        overlay.gameObject.SetActive(false);
        overlayCanvasGroup.blocksRaycasts = false;
    }
    public void SetLosingKing(Player player) {
        setActive();
        text.text = player.GetName() + " er ikke længer konge";
    }
    public void SetLosingMand(Player player) {
        setActive();
        text.text = player.GetName() + " er ikke længere træmand";
    }
    public void SetAddRulesActive(string playerName) {
        setActive();
        text.text = playerName + " tilføj en regel";
    }
}
