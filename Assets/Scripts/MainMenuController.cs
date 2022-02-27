using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    private void Update()
    {
        var cc = FindObjectOfType<CustomController>();
        if (cc.red.wasTriggerdThisFrame)
        {
            ExitGame();
        }
        if (cc.green.wasTriggerdThisFrame)
        {
            PlayGame();
        }
    }

    public void PlayGame()
    {
        GameTools.LoadRandomNewLevel();
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Option1()
    {

    }

    public void Option2()
    {

    }

    public void Option3()
    {

    }

    public void Back()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
