using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class HeldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    private Button _button;
    private bool buttonPressed = false;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void FixedUpdate()
    {
        if (buttonPressed)
            _button.onClick?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_button.interactable) return;

        buttonPressed = true;

    }

    //when pointer released, invokes onRelease event

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonPressed = false;
    }
}