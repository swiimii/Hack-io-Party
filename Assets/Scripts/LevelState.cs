using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Level State is an abstract class, whose child classes can be used to 
/// manage the state of mini-games, and more easily move between levels.
/// </summary>
public abstract class LevelState : MonoBehaviour
{
    /// <summary>
    /// References to the Canvas of a menu 
    /// which will either show success status. Will probably
    /// be the same for every level, and tracked via prefab.
    /// </summary>
    public GameObject victoryScreen, failureScreen;
    
    /// <summary>
    /// For tracking time within level. Tracked via Coroutine in Start function.
    /// </summary>
    public float timeLimit = 8f, timeElapsed = 0f;
    
    /// <summary>
    /// Use to prevent overlapping of victoryScreen and failureScreen.
    /// </summary>
    public bool isFailed = false, isWon = false;
    
    private const float delayBetweenLevels = 2f;

    /// <summary>
    /// These should different for every level.
    /// </summary>
    /// <returns>bool</returns>
    public abstract bool IsAtTargetState();

    protected virtual void Start()
    {
        StartCoroutine(StartTimer());
    }

    public bool CheckVictory()
    {
        if (IsAtTargetState())
        {
            WinLevel();
            StartCoroutine(StartRandomLevel());
            return true;
        }

        return false;
    }

    public IEnumerator StartRandomLevel()
    {
        yield return new WaitForSeconds(delayBetweenLevels);
        var randomlySelectedLevel = (int)(Random.value * (GameTools.lastLevel - GameTools.firstLevel)) + GameTools.firstLevel;
        GameTools.LoadLevel(randomlySelectedLevel);
    }

    public IEnumerator StartTimer()
    {
        while (timeElapsed <= timeLimit)
        {
            yield return null;
            timeElapsed += Time.deltaTime;
            if (timeElapsed > timeLimit)
            {
                isFailed = true;
                if (!CheckVictory() && !isWon)
                {
                    FailLevel();
                }
            }
        }
    }

    public void FailLevel()
    {
        isFailed = true;
        failureScreen.SetActive(true);
    }

    public void WinLevel()
    {
        isWon = true;
        victoryScreen.SetActive(true);
    }

}
