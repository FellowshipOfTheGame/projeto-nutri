using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;

public class JoystickController : OnScreenControl, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] RectTransform _canvas;
    [SerializeField] RectTransform _joystick;
    [SerializeField] RectTransform _background;
    [SerializeField] RectTransform _stick;

    [InputControl(layout = "Vector2")]
    [SerializeField] string _controlPath;
    
    float _joystickMagnitude;
    Vector2 _stickNeutralPosition;
    Vector2 _canvasScreenProportion;

    //float _alwaysShowJoystick;
    //Vector2 _joystickNeutralPosition;

    protected override string controlPathInternal
    {
        get => _controlPath;
        set => _controlPath = value;
    }

    void Start()
    {
        _joystickMagnitude = _background.rect.width / 2 - _stick.rect.width / 2;
        _joystick.gameObject.SetActive(false);
        _stickNeutralPosition = _stick.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData == null) return;

        Rect rect = _canvas.rect;
        _canvasScreenProportion = new Vector2(rect.width / Screen.width, rect.height / Screen.height);
        
        _joystick.gameObject.SetActive(true);
        _joystick.anchoredPosition = eventData.position * _canvasScreenProportion;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData == null) return;

        Vector2 delta = eventData.position * _canvasScreenProportion - _joystick.anchoredPosition;
        
        delta = Vector2.ClampMagnitude(delta, _joystickMagnitude);
        _stick.anchoredPosition = _stickNeutralPosition + delta;
        
        SendValueToControl(new Vector2(delta.x / _joystickMagnitude, delta.y /  _joystickMagnitude));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData == null) return;
        
        _joystick.gameObject.SetActive(false);
        _stick.anchoredPosition = _stickNeutralPosition;
        SendValueToControl(Vector2.zero);
    }
}
