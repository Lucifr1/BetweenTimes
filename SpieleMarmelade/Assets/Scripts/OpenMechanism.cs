using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMechanism : MonoBehaviour
{
    private GameObject door;
    private void OnTriggerEnter2D(Collider2D col)
    {
        door = gameObject.transform.parent.GetChild(1).gameObject;
        if (door.activeSelf)
        {
            door.SetActive(false);
        }
    }
}
