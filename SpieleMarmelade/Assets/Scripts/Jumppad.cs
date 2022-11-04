using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumppad : MonoBehaviour
{
   [SerializeField] private float jumppadPower;

   private void OnTriggerEnter2D(Collider2D other)
   {
      other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumppadPower, ForceMode2D.Impulse);
   }
}
