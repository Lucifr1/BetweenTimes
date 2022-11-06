using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryBarrel : MonoBehaviour
{
    private bool playerInRange;
    private bool carryingBarrel;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (playerInRange)
        {
            if (Input.GetButtonDown("Interact") && !carryingBarrel)
            {
                gameObject.transform.SetParent(player.transform);
                carryingBarrel = true;
            }
            
            else if (Input.GetButtonDown("Interact") && carryingBarrel)
            {
                gameObject.transform.SetParent(null);
                carryingBarrel = false;
            }
        }
    }
}
