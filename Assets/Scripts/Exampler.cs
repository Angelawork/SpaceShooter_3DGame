using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exampler : MonoBehaviour
{
    public string characterName = "Mob";
    public int level = 12;
    private float healthRegen = 1.23f;
    bool Skill = true;
    // Start is called before the first frame update
    void Awake() {
        Debug.Log("Awake");
    }
    void Start()
    {
        Debug.Log("Start");
        LevelUp();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
    }

    void LateUpdate()
    {
        Debug.Log("LateUpdate");
    }


    void LevelUp(){
        level+=1;
    }
}
