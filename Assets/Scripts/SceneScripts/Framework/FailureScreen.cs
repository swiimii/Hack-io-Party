using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailureScreen : MonoBehaviour
{
    void Update()
    {
        var cc = FindObjectOfType<CustomController>();
        if (cc.red.wasTriggerdThisFrame)
        {
            GameTools.LoadScene("MainMenu");
        }
    }
}
