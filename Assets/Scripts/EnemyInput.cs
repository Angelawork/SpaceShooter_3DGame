using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInput : MonoBehaviour
{
    SpaceCraftController _Controller;
    SightTrigger _SightTrigger;
    public float shootDis = 50;
    void Awake()
    {
        _Controller = GetComponent<SpaceCraftController>();
        _SightTrigger = transform.Find("SightTrigger").GetComponent<SightTrigger>();
    }

    private void Update() {
        float forwardValue = 0;
        float turnValue = 0;
        if(_SightTrigger.target){
            turnValue = _SightTrigger.targetAngle * 0.0055f;
            if(_SightTrigger.targetDis>shootDis){
                forwardValue=1;
            }else{
                if(Mathf.Abs(_SightTrigger.targetAngle)<45){
                    _Controller.ShootLaser();
                }
            }
        }
        _Controller.Movement(forwardValue, turnValue);
    }

}
