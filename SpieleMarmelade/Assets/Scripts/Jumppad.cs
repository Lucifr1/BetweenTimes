using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumppad : MonoBehaviour
{
   [SerializeField] private float jumppadPower;
   private Animator jumppad;
   
   [SerializeField] private AudioSource _audioSource;

   private void Start()
   {
      jumppad = gameObject.transform.GetChild(0).GetComponent<Animator>();
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      jumppad.SetBool("boosting", true);
      other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
      StartCoroutine(loadingBoost());
      _audioSource.Play();
      other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumppadPower, ForceMode2D.Impulse);
   }

   IEnumerator loadingBoost()
   {
      yield return new WaitForSeconds(0.1f);
      jumppad.SetBool("boosting", false);
   }
   
}
