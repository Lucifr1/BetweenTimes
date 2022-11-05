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
    private float rotationRadius;
    private float angle = 0f;
    private float posX;
    private float posY;
    private float count = 0.0f;
    private bool activateShoot = false;
    private bool inRange = false;
    private GameObject player;
    private PlayerMovement playerMovement;
    private PlayerController playerController;

    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void SetValues()
    {
        abschussPositionAnpassung = new Vector2(-2f, 1);
        abschussPosition = ((Vector2)transform.position + abschussPositionAnpassung);
        rotationCenter = (zielPosition + abschussPosition)/2;
        centerHelpPosition = rotationCenter + Vector2.up * altitude;
        rotationRadius = Vector2.Distance(rotationCenter, zielPosition);
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
            activateShoot = true;
            playerController.enabled = false;
            playerMovement.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(player.transform.position.x - zielPosition.x) < 0.1 && activateShoot)
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            activateShoot = false;
        }
        if (activateShoot && (Mathf.Abs(player.transform.position.x - zielPosition.x) > 0.1))
        {
            Debug.Log("Schaffen wir es hier wenigstens rein?");
            if (count < 1.0f) {
                count += 1.0f *Time.deltaTime;
                Debug.Log("Schaffen wir es zweimal rein?");
                Vector3 m1 = Vector3.Lerp( abschussPosition, centerHelpPosition, count);
                Vector3 m2 = Vector3.Lerp( centerHelpPosition, zielPosition, count );
                player.transform.position = Vector3.Lerp(m1, m2, count);
            }
        }
        else
        {
            activateShoot = false;
            count = 0f;
            playerController.enabled = true;
            playerMovement.enabled = true;
        }
        
    }
}
