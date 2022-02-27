using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialState
{
    private bool currentState, previousState;
    public bool isActive, wasTriggerdThisFrame, wasReleasedThisFrame;

    public void SetState(bool state)
    {
        previousState = currentState;
        currentState = state;

        isActive = currentState;
        wasTriggerdThisFrame = currentState && !previousState;
        wasReleasedThisFrame = previousState && !currentState;
    }
}
