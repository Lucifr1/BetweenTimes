using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollCredits : MonoBehaviour
{
    public RectTransform boxToMove;
    public ScrollRect scrollRect;
    private float _multiplier = 0;
    private Vector2 _boxPos;

    // Update is called once per frame
    void Update()
    {
        Vector2 v2 = boxToMove.anchoredPosition;
        boxToMove.anchoredPosition = v2 + _multiplier*Vector2.up;
    }

    private void Awake()
    {
        _multiplier = .3f;
        _boxPos = boxToMove.anchoredPosition;
    }

    private void OnDisable()
    {
        boxToMove.anchoredPosition = _boxPos;
        scrollRect.verticalNormalizedPosition = 1;
    }
}