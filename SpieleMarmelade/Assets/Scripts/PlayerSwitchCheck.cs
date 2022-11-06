using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSwitchCheck : MonoBehaviour
{
    private TimeSwitch timeSwitch;
    private AudioSource audioSource;
    
    [SerializeField]
    private AudioClip clip;
    
    void Start()
    {
        audioSource = GameObject.Find("Sound").GetComponent<AudioSource>();
        timeSwitch = GameObject.Find("TimeStateController").GetComponent<TimeSwitch>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("environment"))
        {
            audioSource.Stop();
            timeSwitch.SwitchTimeState();
            audioSource.PlayOneShot(clip);
        }
    }
}