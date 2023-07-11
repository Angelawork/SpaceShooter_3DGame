using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightTrigger : MonoBehaviour
{
    public Transform target;
    Transform _Transform;
    public float targetDis;
    public float targetAngle;
    void Awake() {
        _Transform = GetComponent<Transform>();
    }
    void Update()
    {
        if(target){
            UpdateTargetInfo();
        }
    }

    void UpdateTargetInfo(){
        targetDis = Vector3.Distance(_Transform.position, target.position);
        Vector3 targetDir = target.position - _Transform.position;
        targetAngle = Vector3.SignedAngle(_Transform.forward, targetDir, Vector3.up);
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag=="Player"){
            target = other.transform;
            UpdateTargetInfo();
        }
    }
    void OnTargetExit(Collider other){
        if(other.transform == target){
            target = null;
        }
    }
}
