using Assets.Scripts.SceneScripts.Level5;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public GameObject floor;
    public int numSteps = 15;

    // Start is called before the first frame update
    void Start()
    {
        var path = GeneratePath();
        SpawnPath(path);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnPath(Step[] steps)
    {
        int timeOffset = 4;
        
        for(int i = 0; i <steps.Length; i++)
        {
            var currentStep = steps[i];

            int position;

            // Find Goal Position
            switch (currentStep.targetPosition)
            {
                case StepPosition.Left:
                    position = -1;
                    break;
                case StepPosition.Right:
                    position = 1;
                    break;
                case StepPosition.Center:
                    position = 0;
                    break;
                default:
                    position = 0;
                    break;
            }

            // Offset goal postition based on desired arrival time
            if(currentStep.entryDirection == StepDirection.Left)
            {
                position += timeOffset * (i + 2) * -1;
            }
            else
            {
                position += timeOffset * (i + 2) * 1;
            }

            // Spawn in step

            var step = Instantiate(floor, new Vector2(position, i * 2.5f - 2f), Quaternion.identity).GetComponent<StepFloor>();
            step.entryDirection = currentStep.entryDirection;


        }
    }

    private Step[] GeneratePath()
    {
        var output = new Step[numSteps];

        var firstStep = new Step() { entryDirection = StepDirection.Right, targetPosition = StepPosition.Center };
        output[0] = firstStep;

        for(int i = 1; i < numSteps; i++)
        {
            var newStep = new Step();
            newStep.targetPosition = GetRandomPosition(output[i - 1].targetPosition);
            newStep.entryDirection = GetRandomDirection(newStep.targetPosition, output[i - 1].targetPosition);

            output[i] = newStep;
        }

        return output;
    }

    private StepDirection GetRandomDirection(StepPosition currentStep, StepPosition lastStep)
    {
        // LL -> R
        // LC -> LR
        // CL -> LR
        // CC -> LR
        // CR -> LR
        // RC -> LR
        // RR -> L

        if (lastStep == StepPosition.Left && currentStep == StepPosition.Left)
        {
            return StepDirection.Right;
        }
        else if (lastStep == StepPosition.Right && lastStep == StepPosition.Right)
        {
            return StepDirection.Left;
        }
        else
        {
            var rand = Random.Range(1, 100);

            return (rand > 50) ? StepDirection.Left : StepDirection.Right;
        }

    }

    private StepPosition GetRandomPosition(StepPosition lastStep)
    {
        // L -> LC
        // C -> LCR
        // R ->  CR

        var rand = Random.Range(1, 100);

        switch (lastStep)
        {
            case StepPosition.Left:
                return (rand > 50) ? StepPosition.Left : StepPosition.Center;
            case StepPosition.Right:
                return (rand > 50) ? StepPosition.Center : StepPosition.Right;
            case StepPosition.Center:
                if(rand > 66)
                {
                    return StepPosition.Left;
                }
                else if(rand > 33)
                {
                    return StepPosition.Center;
                }
                else
                {
                    return StepPosition.Right;
                }
        }

        return StepPosition.Center; // Intell is dumb
    }
}
