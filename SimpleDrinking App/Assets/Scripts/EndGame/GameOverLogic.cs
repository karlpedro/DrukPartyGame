using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverLogic : MonoBehaviour
{
    public GameObject gameOverOverlay;
    public RuleTextBoxManager ruleTextBoxManager;
    public CardEffects cardEffects;

    public CanvasGroup overlayCanvasGroup;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerGameOver()
    {
        gameObject.SetActive(true);  
        overlayCanvasGroup.blocksRaycasts = true;
    }

    public void HideGameOver()
    {
        gameObject.SetActive(false); 
        overlayCanvasGroup.blocksRaycasts = false; 
    }

    public void RestartGame() {
        SceneManager.LoadScene(0);
        gameOverOverlay.SetActive(false);
        cardEffects.ResetCardEffects();
        Screen.orientation = ScreenOrientation.Portrait;
    }

    public void continueGame() {
        cardEffects.ResetCardEffects();
        HideGameOver();
    }
}
