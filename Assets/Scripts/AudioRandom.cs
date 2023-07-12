using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandom : MonoBehaviour
{
    private AudioSource _AudioSource;
    public AudioClip[] audioArray;
    void Awake(){
        _AudioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        _AudioSource.clip = audioArray[Random.Range(0, audioArray.Length)];
        _AudioSource.Play();
    }
}
