using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTools
{
    public static int firstLevel = 1, lastLevel = 3;

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

    }
}
