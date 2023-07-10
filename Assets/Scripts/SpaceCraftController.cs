using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCraftController : MonoBehaviour
{
    public float moveSpeed = 30;
    public float rotationSpeed = 15;
    public GameObject laserPrefab;
    public Transform reCalTransform;
    public Transform[] shootPosArray;
    private Transform _Transform;
    private Rigidbody _Rigidbody;

    void Awake(){
        _Rigidbody = GetComponent<Rigidbody>();
        _Transform = GetComponent<Transform>();
    }

    /*
    void Update()
    {
        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        moveDir = reCalTransform.TransformDirection(moveDir);
        Movement(moveDir);

        if(Input.GetKeyDown(KeyCode.Space)){
            ShootLaser();
        }
        /*
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            Movement(new Vector3(0,0,60));
            //transform.position -= new Vector3(0,0,50.5f)*Time.deltaTime;
        }
        if(Input.GetKeyUp(KeyCode.UpArrow)){
            Movement(Vector3.zero);
        }
        // 
    }*/
    
    public void Movement(Vector3 dir){
        _Rigidbody.velocity = dir*moveSpeed;
        if(dir!=Vector3.zero){
            Quaternion rotationValue = Quaternion.LookRotation(dir);
            _Transform.rotation = Quaternion.Slerp(_Transform.rotation, rotationValue, Time.deltaTime * rotationSpeed);
        }
    }

    public void ShootLaser(){
        for(int i=0; i<shootPosArray.Length; i++){
            Instantiate(laserPrefab, shootPosArray[i].position, shootPosArray[0].rotation);
        }
    }
}
