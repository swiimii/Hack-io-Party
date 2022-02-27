using Assets.Scripts.SceneScripts.Level5;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepFloor : MonoBehaviour
{
    public StepDirection entryDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        var directionMultiplier = (entryDirection == StepDirection.Left) ? 1 : -1;
        transform.Translate(new Vector2(directionMultiplier * 4.0f * 0.5f * Time.deltaTime, 0));

    }

}
