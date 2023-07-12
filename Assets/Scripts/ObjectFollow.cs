using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour
{
    Vector3 offsetPos = new Vector3(-12.9f,47.9f,-68.7f);
    public Transform target;
    void Update()
    {
        if(target){
            transform.position = target.position+offsetPos;
        }
    }
}
