using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public float moveSpeed = 100;
    public float lifeTime = 1.1f;

    void Start(){
        Destroy(gameObject, lifeTime);
    }
    void Update()
    {
        transform.position += transform.forward*moveSpeed*Time.deltaTime;
    }
    void OnTriggerEnter(Collider other) {
         if(other.CompareTag("Ground")){
            Destroy(gameObject);
         }
    }
}
