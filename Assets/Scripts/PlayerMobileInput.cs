using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobileInput : MonoBehaviour
{
    public JoyStickController _Joystick;
    SpaceCraftController _Controller;
    public Transform reCalTransform;
    private bool isShoot = false;
    private void Awake() {
        _Controller  =GetComponent<SpaceCraftController>();
    }
    void Update()
    {
        Vector3 moveDir = new Vector3(_Joystick.joystickX,0,_Joystick.joystickY);
        moveDir = reCalTransform.TransformDirection(moveDir);
        _Controller.Movement(moveDir);

        if(isShoot){
            _Controller.ShootLaser();
        }
    }
    public void OnPressShoot(bool isPress){
        isShoot = isPress;
    }
}
