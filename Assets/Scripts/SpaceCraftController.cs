using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCraftController : MonoBehaviour
{
    public int healthPoint = 10;
    public float moveSpeed = 30;
    public float rotationSpeed = 15;
    public float shootTime = 0.5f;
    float timer;
    float shootCoolDownTime;
    public GameObject laserPrefab;
    public Transform reCalTransform;
    public Transform[] shootPosArray;
    public GameObject destroyEffect;
    
    private Transform _Transform;
    private Rigidbody _Rigidbody;
    bool isAlive=true;
    private AudioSource _AudioSource;
    public AudioClip[] _lasersound;

    void Awake(){
        _Rigidbody = GetComponent<Rigidbody>();
        _Transform = GetComponent<Transform>();
        _AudioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        timer+=Time.deltaTime;
    }
        /*
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
        */
    
    public void Movement(Vector3 dir){
        _Rigidbody.velocity = dir*moveSpeed;
        if(dir!=Vector3.zero){
            Quaternion rotationValue = Quaternion.LookRotation(dir);
            _Transform.rotation = Quaternion.Slerp(_Transform.rotation, rotationValue, Time.deltaTime * rotationSpeed);
        }
    }
    public void Movement(float dirV, float dirH){
        _Rigidbody.velocity = transform.forward*dirV*moveSpeed;
        _Transform.Rotate(transform.up, dirH*Time.deltaTime*rotationSpeed, Space.World);
    }

    public void ShootLaser(){
        if(timer>=shootCoolDownTime){
            shootCoolDownTime = timer+shootTime;
            CreateLaser();
        }
    }
    public void CreateLaser(){
        int number = Random.Range(0, _lasersound.Length);
        _AudioSource.PlayOneShot(_lasersound[number]);

        for(int i=0; i<shootPosArray.Length; i++){
            Instantiate(laserPrefab, shootPosArray[i].position, shootPosArray[0].rotation);
        }
    }
    public void UnderAttack(int value){
        healthPoint-=value;
        if(gameObject.CompareTag("Player")){
            GameManager.singleton.UpdateHealthPoint(healthPoint);
        }
        if(healthPoint<=0){
            Dead();
        }
    }
    void Dead(){
        isAlive = false;
        if(gameObject.CompareTag("Player")){
            GameManager.singleton.GameFail();
        }else if(gameObject.CompareTag("Enemy")){
            GameManager.singleton.GetScore();
        }
        Instantiate(destroyEffect, _Transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
