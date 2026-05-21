using UnityEngine;
using UnityEngine.EventSystems;

public class TouchButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public enum ButtonType
    {
        Left,
        Right,
        Jump
    }

    public ButtonType buttonType;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (buttonType == ButtonType.Left)
            MobileInput.moveLeft = true;

        if (buttonType == ButtonType.Right)
            MobileInput.moveRight = true;

        if (buttonType == ButtonType.Jump)
            MobileInput.jump = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (buttonType == ButtonType.Left)
            MobileInput.moveLeft = false;

        if (buttonType == ButtonType.Right)
            MobileInput.moveRight = false;

        if (buttonType == ButtonType.Jump)
            MobileInput.jump = false;
    }
}