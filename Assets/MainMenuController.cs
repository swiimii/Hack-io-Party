using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject targetLocation;

    public float menuMoveSpeed = 10;

    bool toMainMenu = false;
    bool toOptions = false;

    Vector3 mainMenuTargetEnter = new Vector3(0, 340, 0);
    Vector3 optionsMenuTargetEnter = new Vector3(0, 0, 0);
    Vector3 mainMenuTargetExit = new Vector3(0, 1300, 0);
    Vector3 optionsMenuTargetExit = new Vector3(0, -1000, 0);

    private void FixedUpdate()
    {
        float step = menuMoveSpeed * Time.deltaTime;
        if (toMainMenu)
        {
            mainMenu.transform.position = Vector3.MoveTowards(mainMenu.transform.position, targetLocation.transform.position, step);
            optionsMenu.transform.position = Vector3.MoveTowards(optionsMenu.transform.position, optionsMenuTargetExit, step);
            if (mainMenu.transform.position == targetLocation.transform.position && optionsMenu.transform.position == optionsMenuTargetExit)
            {
                optionsMenu.SetActive(false);
                toMainMenu = false;
            }
        }
        else if (toOptions)
        {
            mainMenu.transform.position = Vector3.MoveTowards(mainMenu.transform.position, mainMenuTargetExit, step);
            optionsMenu.transform.position = Vector3.MoveTowards(optionsMenu.transform.position, targetLocation.transform.position, step);
            if (mainMenu.transform.position == mainMenuTargetExit && optionsMenu.transform.position == targetLocation.transform.position)
            {
                mainMenu.SetActive(false);
                toOptions = false;
            }
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Options()
    {
        optionsMenu.SetActive(true);
        if (toMainMenu == false)
        {
            toOptions = true;
        }
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
        mainMenu.SetActive(true);
        if (toOptions == false)
        {
            toMainMenu = true;
        }
    }
}
