using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMechanism : MonoBehaviour
{
    private GameObject door;
    private Vector3 scaleChange;
    private Animator doorAnimator;

    private void Start()
    {
        doorAnimator = gameObject.transform.parent.GetChild(1).gameObject.GetComponent<Animator>();
        scaleChange = new Vector3(0, -0.3f, 0);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        door = gameObject.transform.parent.GetChild(1).gameObject;
        if (door.GetComponent<Collider2D>().enabled)
        {
            doorAnimator.SetTrigger("buttonPress");
            door.GetComponent<Collider2D>().enabled = false;
            gameObject.transform.GetChild(0).transform.localScale += scaleChange;
        }
    }
}
