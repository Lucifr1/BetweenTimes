using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSwitch : MonoBehaviour
{
    [SerializeField] GameObject PastLevel;
    [SerializeField] GameObject FutureLevel;

    private enum TimeState {past, future};
    private TimeState timeState;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SwitchTimeState();
        }
    }

    private void SwitchTimeState()
    {
        switch (timeState)
        {
            case TimeState.past:
                PastLevel.SetActive(false);
                FutureLevel.SetActive(true);
                timeState = TimeState.future;
                break;
            case TimeState.future:
                PastLevel.SetActive(true);
                FutureLevel.SetActive(false);
                timeState = TimeState.past;
                break;
        }
    }
}