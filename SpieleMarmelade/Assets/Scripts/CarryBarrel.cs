using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarryBarrel : MonoBehaviour
{
    private bool playerInRange;
    private bool carryingBarrel = false;
    [SerializeField] private GameObject player;

    private void Start()
    {
        gameObject.transform.SetParent(gameObject.transform.GetChild(0));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            gameObject.transform.GetChild(0).GetChild(0).GameObject().SetActive(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            gameObject.transform.GetChild(0).GetChild(0).GameObject().SetActive(false);
        }
    }

    private void Update()
    {
        CheckInput();
    }
    private void CheckInput()
    {
        if (Input.GetButtonDown("Interact") && !carryingBarrel && playerInRange)
        {
                Debug.Log("Wir tragen dich rum");
                gameObject.transform.SetParent(player.transform);
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                //gameObject.GetComponent<Rigidbody2D>().
                carryingBarrel = true;
                gameObject.transform.GetChild(0).GetChild(0).GameObject().SetActive(false);
                gameObject.transform.GetChild(0).GetChild(1).GameObject().SetActive(true); 
        }
            
        else if (Input.GetButtonDown("Interact") && carryingBarrel)
        {
                Debug.Log("Wir lassen dich fallen");
                gameObject.transform.SetParent(null);
                carryingBarrel = false;
                gameObject.transform.GetChild(0).GetChild(1).GameObject().SetActive(false);
        }
        
    }
}
