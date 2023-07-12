using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public float moveSpeed = 100;
    public float lifeTime = 1.1f;
    public bool isPlayerLaser;
    public GameObject breakParticle;

    void Start(){
        Destroy(gameObject, lifeTime);
    }
    void Update()
    {
        transform.position += transform.forward*moveSpeed*Time.deltaTime;
    }
    void OnTriggerEnter(Collider other) {
         if(other.CompareTag("Ground")){
            DestroyLaser();
         }
         if(isPlayerLaser && other.CompareTag("Enemy")){
            other.GetComponent<SpaceCraftController>().UnderAttack(1);
            DestroyLaser();
         }else if (!isPlayerLaser && other.CompareTag("Player")){
            other.GetComponent<SpaceCraftController>().UnderAttack(1);
            DestroyLaser();
         }
    }
    void DestroyLaser(){
        Instantiate(breakParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
