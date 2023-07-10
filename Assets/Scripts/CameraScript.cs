using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake(){
        gameObject.SetActive(false);
    }
    void Start()
    {
        GetComponent<Camera>().enabled = false;
    }
}
