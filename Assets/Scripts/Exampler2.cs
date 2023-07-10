using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exampler2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Exampler>().level = 9;
        GetComponent<Exampler>().characterName = "Master";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
