using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour
{
    Vector3 offsetPos = new Vector3(-7.6f,56f,-49.8f);
    public Transform target;
    void Update()
    {
        if(target){
            transform.position = target.position+offsetPos;
        }
    }
}
