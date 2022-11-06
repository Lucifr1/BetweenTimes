using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSwitchCheck : MonoBehaviour
{
    private TimeSwitch timeSwitch;
    
    void Start()
    {
        timeSwitch = GameObject.Find("TimeStateController").GetComponent<TimeSwitch>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("environment"))
        {
            timeSwitch.SwitchTimeState();
        }
    }
}