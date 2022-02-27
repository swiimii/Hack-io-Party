using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailureScreen : MonoBehaviour
{
    public Text score, highScore;

    private void Start()
    {
        score.text = "Score: " + PlayerPrefs.GetInt("LatestScore");
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }

    void Update()
    {
        var cc = FindObjectOfType<CustomController>();
        if (cc.red.wasTriggerdThisFrame)
        {
            GameTools.LoadScene("MainMenu");
        }
    }
}
