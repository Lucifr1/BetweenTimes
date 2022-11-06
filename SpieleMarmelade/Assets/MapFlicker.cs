using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapFlicker : MonoBehaviour
{
    private float flickerCooldown = 5;
    private float flickerOffCooldown = .2f;
    private GameObject container;
    void Start()
    {
        container = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        while (flickerCooldown > 0)
        {
            flickerCooldown -= Time.deltaTime;
        }
        while (flickerOffCooldown > 0)
        {
            flickerOffCooldown -= Time.deltaTime;
        }

        if (flickerCooldown < .1f)
        {
            container.SetActive(true);
            Debug.Log("Active");
            flickerOffCooldown = .2f;
        }

        if (flickerOffCooldown < .1f)
        {
            Debug.Log("Inactive");
            container.SetActive(false);
            flickerCooldown = 5f;
        }


    }
}
