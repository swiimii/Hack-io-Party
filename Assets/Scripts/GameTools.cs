using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTools
{
    public static int firstLevel = 1;
    public static int lastLevel => SceneManager.sceneCountInBuildSettings - 1;
    public static int score = 0;

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void LoadLevel(int level)
    {
        SceneManager.LoadScene("Level" + level);
    }

    public static void LoadRandomNewLevel()
    {
        var thisLevel = SceneManager.GetActiveScene().buildIndex;
        var randomlySelectedLevel = (int)(Random.value * (lastLevel - firstLevel) + 1);

        // This prevents the currently selected level from being chosen,
        // but also allows every level to have an equal chance of being chosen
        if (randomlySelectedLevel >= thisLevel)
        {
            randomlySelectedLevel += 1;
        }
        LoadLevel(randomlySelectedLevel);
    }
}
