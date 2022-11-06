using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public Vector3 checkpoint;
    public GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        checkpoint = player.transform.position;
    }
    
    public void CreateCheckpoint()
    {
        checkpoint = player.transform.position;
    }

    public void LoadCheckpoint()
    {
        player.transform.position = checkpoint;
    }
}
