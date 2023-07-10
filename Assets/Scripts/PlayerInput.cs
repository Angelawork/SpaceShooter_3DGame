using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Transform reCalTransform;
    SpaceCraftController _Controller;
    void Awake(){
        _Controller = GetComponent<SpaceCraftController>();
    }

    void Update()
    {
        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        moveDir = reCalTransform.TransformDirection(moveDir);
        _Controller.Movement(moveDir);

        if(Input.GetKeyDown(KeyCode.Space)){
            _Controller.ShootLaser();
        }  
    }
}
