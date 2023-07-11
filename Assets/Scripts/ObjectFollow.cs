using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour
{
    Vector3 offsetPos = new Vector3(-5.4f,45.3f,-38.5f);
    public Transform target;
    void Update()
    {
        if(target){
            transform.position = target.position+offsetPos;
        }
    }
}
