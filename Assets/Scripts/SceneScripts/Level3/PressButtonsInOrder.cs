using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class PressButtonsInOrder : LevelState
{
    public GameObject highlightObject;
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
            correctSequence.Add((int)(Random.value * numButtons)+1);
        }
        
        base.Start();

        StartCoroutine(ShowPattern());
    }

    private void Update()
    {
        var cc = FindObjectOfType<CustomController>();

        if (cc.red.wasTriggerdThisFrame)
        {
            inputtedSequence.Add(2);
            CheckInput();
        }

        if (cc.green.wasTriggerdThisFrame)
        {
            inputtedSequence.Add(3);
            CheckInput();
        }

        if (cc.yellow.wasTriggerdThisFrame)
        {
            inputtedSequence.Add(1);
            CheckInput();
        }

        if (cc.blue.wasTriggerdThisFrame)
        {
            inputtedSequence.Add(4);
            CheckInput();
        }
    }

    private void CheckInput()
    {
        if (inputtedSequence.Count > correctSequence.Count)
        {
            FailLevel();
        }
        var index = Mathf.Min(inputtedSequence.Count - 1, correctSequence.Count - 1);
        if (inputtedSequence[index] != correctSequence[index])
        {
            FailLevel();
        }
        if (inputtedSequence.Count == correctSequence.Count)
        {
            CheckVictory();
        }
    }

    public override bool IsAtTargetState()
    {
        return Enumerable.SequenceEqual(inputtedSequence, correctSequence);
    }

    public IEnumerator ShowPattern()
    {
        yield return new WaitForSeconds(.5f);
        for (var i = 0; i < correctSequence.Count; i++)
        {
            highlightObject.SetActive(true);
            highlightObject.transform.position = buttonHighlightLocations[correctSequence[i]-1].position;
            yield return new WaitForSeconds(.5f);
            highlightObject.SetActive(false);
            yield return new WaitForSeconds(.25f);

        }
    }
}
