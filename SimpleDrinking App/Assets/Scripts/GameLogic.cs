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
        // Automatically switch orientation based on device rotation
        UpdateOrientation();

        if (touchActive)
        {
            touchTime += Time.deltaTime;
            if (touchTime >= holdThreshold)
            {
                isHolding = true;
            }
        }

        if (Input.touchCount == 0 && touchActive)
        {
            if (!isHolding)
            {
                HandleClick();
            }

            touchActive = false;
            isHolding = false;
            touchTime = 0f;
        }
    }

    private void UpdateOrientation()
    {
        // Convert device orientation to ScreenOrientation
        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
        {
            SetLandscapeOrientation(ScreenOrientation.LandscapeLeft);
        }
        else if (Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            SetLandscapeOrientation(ScreenOrientation.LandscapeRight);
        }
    }

    public void SetLandscapeOrientation(ScreenOrientation orientation)
    {
        if (orientation == Screen.orientation)
        {
            return; // Do nothing if the orientation is already set
        }

        Screen.orientation = orientation;
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
