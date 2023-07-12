using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickController : MonoBehaviour
{
    public RectTransform _RectTrans;
    public Vector3 startPos;
    public float joystickX;
    public float joystickY;
    private float clampPos;
    private float fixPos;
    void Start()
    {
        _RectTrans = transform.Find("Controller").GetComponent<RectTransform>();
        startPos = _RectTrans.position;

        clampPos = GetComponent<RectTransform>().sizeDelta.x / 2;
        fixPos = 1/clampPos;
    }
    void Update()
    {
        
    }
    public void OnDrag(BaseEventData eventData){
        PointerEventData data = eventData as PointerEventData;
        _RectTrans.position = data.position;
        _RectTrans.localPosition = Vector3.ClampMagnitude(_RectTrans.localPosition, clampPos);

        joystickX = _RectTrans.localPosition.x*fixPos;
        joystickY = _RectTrans.localPosition.y*fixPos;
    }
    public void OnEndDrag(BaseEventData eventData){
        _RectTrans.position = startPos;
        joystickX = 0;
        joystickY = 0;
    }
}
