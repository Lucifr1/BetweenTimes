using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KatapultMechanism : MonoBehaviour
{
    [SerializeField] private Vector2 zielPosition;
    [SerializeField] private float altitude;
    private Vector2 abschussPosition;
    private Vector2 abschussPositionAnpassung;
    private Vector2 rotationCenter;
    private Vector2 centerHelpPosition;
    private float posX;
    private float posY;
    private float count = 0.0f;
    private bool activateShoot = false;
    private bool inRange = false;
    public static bool catapultflying;
    private GameObject player;
    private PlayerMovement playerMovement;
    private PlayerController playerController;
    [SerializeField] private Animator catapult;
    private Animator playerCatapult;

    private void Start()
    {
        //playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        //playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerCatapult = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

    }

    private void SetValues()
    {
        abschussPositionAnpassung = new Vector2(-1.9f, 0.38f);
        abschussPosition = ((Vector2)transform.position + abschussPositionAnpassung);
        rotationCenter = (zielPosition + abschussPosition)/2;
        centerHelpPosition = rotationCenter + Vector2.up * altitude;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        inRange = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && inRange)
        {
            SetValues();
            player.transform.position = abschussPosition;
            StartCoroutine(KatapultTimer());
        }
    }
    IEnumerator KatapultTimer()
    { 
        //playerController.enabled = false;
       //playerMovement.enabled = false;
       Debug.Log("Ja auch mal hier");
       catapultflying = true;
       player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
       playerCatapult.SetFloat("speed", 0);
       yield return new WaitForSeconds(0.25f);
       player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
       player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
       playerCatapult.SetBool("flying", true);
       catapult.SetTrigger("shoot");
       activateShoot = true;
    }
    private void FixedUpdate()
    {
        /*if (Mathf.Abs(player.transform.position.x - zielPosition.x) < 0.1 && activateShoot)
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            activateShoot = false;
        }
        else */
        if (activateShoot && (Mathf.Abs(player.transform.position.x - zielPosition.x) > 0.1))
        {
            if (count < 1.0f) {
                count += 1.0f *Time.deltaTime;
                Vector3 m1 = Vector3.Lerp( abschussPosition, centerHelpPosition, count);
                Vector3 m2 = Vector3.Lerp( centerHelpPosition, zielPosition, count );
                player.transform.position = Vector3.Lerp(m1, m2, count);
                Debug.Log(catapultflying);
            }
        }
        else if(Mathf.Abs(player.transform.position.x - zielPosition.x) < 0.1)
        {
            Debug.Log("Ich will hier nicht sein");
            playerCatapult.SetBool("flying", false);
            catapultflying = false;
            activateShoot = false;
            count = 0f;
            //playerController.enabled = true;
            //playerMovement.enabled = true;
        }
    }
    
    
}
