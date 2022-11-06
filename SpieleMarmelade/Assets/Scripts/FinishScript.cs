using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishScript : MonoBehaviour
{
    public Image image;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            KatapultMechanism.catapultflying = true;
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            image.gameObject.SetActive(true);
        }
    }
}
