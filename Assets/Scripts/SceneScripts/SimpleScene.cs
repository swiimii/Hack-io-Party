using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleScene : LevelState
{

    public override bool IsAtTargetState()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            return true;
        }
        return false;
    }

    public void Update()
    {
        if (IsAtTargetState())
        {
            WinLevel();
        }
    }
}
