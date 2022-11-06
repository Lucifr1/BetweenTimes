using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private PlayerController playerController;

    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _audioSource = GameObject.Find("Sound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.dead = true;
            _audioSource.PlayOneShot(playerController.deathSounds[Random.Range(0, playerController.deathSounds.Length)]);
            playerController.deathTimer = 1.5f;
        }
    }
}