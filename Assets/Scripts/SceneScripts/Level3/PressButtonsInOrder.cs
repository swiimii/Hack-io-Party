using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class PressButtonsInOrder : LevelState
{

    public Transform[] buttonHighlightLocations;
    public List<int> correctSequence;
    public List<int> inputtedSequence;

    public int sequenceLength = 4;
    private const int numButtons = 4;

    // Start is called before the first frame update
    protected override void Start()
    {
        correctSequence = new List<int>(4);
        for (var i = 0; i < sequenceLength; i++)
        {
            correctSequence.Add((int)(Random.value * numButtons));
        }
        
        base.Start();
    }

    public override bool IsAtTargetState()
    {
        return Enumerable.SequenceEqual(inputtedSequence, correctSequence);
    }
}
