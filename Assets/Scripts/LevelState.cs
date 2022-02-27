using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject victoryScreen, failureScreen, timerCanvas;

    public Text timerComponent;

    /// <summary>
    /// For tracking time within level. Tracked via Coroutine in Start function.
    /// </summary>
    public float timeLimit = 8f, timeElapsed = 0f;
    
    /// <summary>
    /// Use to prevent overlapping of victoryScreen and failureScreen.
    /// </summary>
    public bool isFailed = false, isWon = false;
    public bool disableTimer = false;
    
    private const float delayBetweenLevels = 2f;

    /// <summary>
    /// These should different for every level.
    /// </summary>
    /// <returns>bool</returns>
    public abstract bool IsAtTargetState();

    protected virtual void Start()
    {
        if (!disableTimer) StartCoroutine(StartTimer());
    }

    public virtual bool CheckVictory()
    {
        if (IsAtTargetState() && !isFailed)
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
        GameTools.LoadRandomNewLevel();
    }

    public IEnumerator StartTimer()
    {
        while (timeElapsed <= timeLimit)
        {
            yield return null;
            timeElapsed += Time.deltaTime;
            timerComponent.text = (Mathf.Max(timeLimit - timeElapsed, 0)).ToString("F1");
            if (timeElapsed > timeLimit)
            {
                if (!CheckVictory() && !isWon)
                {
                    FailLevel();
                }
            }
            if (isWon)
            {
                break;
            }
        }
    }

    public virtual void FailLevel()
    {
        isFailed = true;
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        PlayerPrefs.SetInt("HighScore", Mathf.Max(PlayerPrefs.GetInt("HighScore"), GameTools.score));
        PlayerPrefs.SetInt("LatestScore", GameTools.score);
        GameTools.score = 0;
        PlayerPrefs.Save();
        failureScreen.SetActive(true);
    }

    public virtual void WinLevel()
    {
        if (!isWon && !isFailed)
            GameTools.score++;
        isWon = true;
        victoryScreen.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        GameTools.LoadScene("MainMenu");
    }

}
