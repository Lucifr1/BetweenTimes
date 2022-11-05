using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PlatformMovement : MonoBehaviour
{
    private Vector2 firstPosition;
    [SerializeField] private Vector2 secondPosition;
    [SerializeField] private int speed;
    private bool hasReachedFirst = false;
    private bool hasReachedSecond = true;
    private Vector2 startPosition = Vector2.zero;
    private void Awake()
    {
        startPosition = transform.position;
        firstPosition = startPosition;
    }

    private void FixedUpdate()
    {
        if (!hasReachedFirst)
        {
            if (Vector2.Distance(firstPosition, transform.position) != 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, firstPosition, speed * Time.deltaTime);
            }
            else
            {
                hasReachedFirst = true;
                hasReachedSecond = false;
            }
        }
        else if (!hasReachedSecond)
        {
            if (Vector2.Distance(secondPosition, transform.position) != 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, secondPosition, speed * Time.deltaTime);
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
