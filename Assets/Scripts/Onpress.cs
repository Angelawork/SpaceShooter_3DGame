using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Onpress : MonoBehaviour
{
    public Sprite newButtonImage;
    public Button button;
    void Update()
    {
        
    }
    public void ChangeButtonImage(){
        button.image.sprite  = newButtonImage;
    }
}
