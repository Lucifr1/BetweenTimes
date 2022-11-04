using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private Vector3 firstPosition;
    [SerializeField] private Vector3 secondPosition;
    [SerializeField] private int speed;
    private bool hasReachedFirst = false;
    private bool hasReachedSecond = true;
    private Vector3 startPosition = Vector3.zero;
    private void Awake()
    {
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (!hasReachedFirst)
        {
            if (Vector3.Distance(firstPosition, transform.position) != 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, firstPosition, speed * Time.deltaTime);
            }
            else
            {
                hasReachedFirst = true;
                hasReachedSecond = false;
            }
        }
        else if (!hasReachedSecond)
        {
            if (Vector3.Distance(secondPosition, transform.position) != 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, secondPosition, speed * Time.deltaTime);
            }
            else
            {
                hasReachedFirst = false;
                hasReachedSecond = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.transform.SetParent(null);
    }
}
