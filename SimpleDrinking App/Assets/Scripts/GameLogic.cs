using UnityEngine;
using UnityEngine.EventSystems;

public class GameLogic : MonoBehaviour, IPointerDownHandler
{
    public TextOutputs textOut;
    public OverLayScript overlay;
    public GameObject overlayObject;
    public GameObject rulesButton;

    // This method is called when a touch is initiated on the panel (Android)
    public void OnPointerDown(PointerEventData eventData)
    {   
        Debug.Log("Is rules button active?: " +rulesButton.activeSelf);
        if (!overlayObject.activeSelf)
        {
            textOut.ChangeText();
        }
        else if (rulesButton.activeSelf) {
            // do nothing
        }
        else {
            overlay.setNotActive();
        }
    }
}
