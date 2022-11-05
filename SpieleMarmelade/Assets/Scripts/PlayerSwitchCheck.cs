using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSwitchCheck : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private LayerMask futureLayerMask;
    [SerializeField] private LayerMask pastLayerMask;
    
    void Start()
    {
        player = gameObject;
    }

    public bool isColliding(String switchedToLevel)
    {
        //Future
        if (switchedToLevel == "future")
        {
            if (!(Physics.OverlapSphere(player.transform.position, 0.5f, futureLayerMask) == null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        //Past
        if (switchedToLevel == "past")
        {
            if (!(Physics.OverlapSphere(player.transform.position, 0.5f, pastLayerMask) == null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
}