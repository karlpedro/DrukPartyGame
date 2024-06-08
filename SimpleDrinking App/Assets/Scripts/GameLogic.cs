using UnityEngine;
using UnityEngine.EventSystems;

public class GameLogic : MonoBehaviour, IPointerDownHandler
{
    public TextOutputs textOut;
    public OverLayScript overlay;
    public GameObject overlayObject;
    public GameObject rulesButton;

    public float holdThreshold = 0.5f; // Threshold time in seconds to consider as hold
    private bool isHolding = false;
    private float touchTime = 0f;
    private bool touchActive = false;

    void Update()
    {
        if (touchActive)
        {
            // Increment the touch time if touch is active
            touchTime += Time.deltaTime;

            // Check if the touch duration has exceeded the hold threshold
            if (touchTime >= holdThreshold)
            {
                isHolding = true;
            }
        }

        // If touch ended and not holding
        if (Input.touchCount == 0 && touchActive)
        {
            if (!isHolding)
            {
                // Short touch, handle click
                HandleClick();
            }

            // Reset touch state
            touchActive = false;
            isHolding = false;
            touchTime = 0f;
        }
    }

    // Called when a touch is initiated on the panel (Android)
    public void OnPointerDown(PointerEventData eventData)
    {
        touchActive = true;
        touchTime = 0f;
        isHolding = false;
    }

    private void HandleClick()
    {
        Debug.Log("Is rules button active?: " + rulesButton.activeSelf);
        if (!overlayObject.activeSelf)
        {
            textOut.ChangeText();
        }
        else if (!rulesButton.activeSelf)
        {
            overlay.setNotActive();
        }
        // If rulesButton is active, do nothing
    }
}
