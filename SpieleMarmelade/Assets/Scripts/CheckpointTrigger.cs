using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    private CheckpointController checkpointController;

    private void Start()
    {
        checkpointController = GameObject.Find("GameController").GetComponent<CheckpointController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        checkpointController.CreateCheckpoint();
    }
}
