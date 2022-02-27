using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public Transform topTarget;
    public Transform centerTarget;
    public Transform bottomTarget;

    public float menuMoveSpeed = 10;

    bool toMainMenu = false;
    bool toOptions = false;

    private void FixedUpdate()
    {
        float step = menuMoveSpeed * Time.deltaTime;
        if (toMainMenu)
        {
            mainMenu.transform.position = Vector3.MoveTowards(mainMenu.transform.position, centerTarget.position, step);
            optionsMenu.transform.position = Vector3.MoveTowards(optionsMenu.transform.position, bottomTarget.position, step);
            if (mainMenu.transform.position == centerTarget.position && optionsMenu.transform.position == bottomTarget.position)
            {
                optionsMenu.SetActive(false);
                toMainMenu = false;
                Debug.Log("toMainMenu = false");
            }
        }
        else if (toOptions)
        {
            mainMenu.transform.position = Vector3.MoveTowards(mainMenu.transform.position, topTarget.position, step);
            optionsMenu.transform.position = Vector3.MoveTowards(optionsMenu.transform.position, centerTarget.position, step);
            if (mainMenu.transform.position == topTarget.position && optionsMenu.transform.position == centerTarget.position)
            {
                mainMenu.SetActive(false);
                toOptions = false;
                Debug.Log("toOptions = false");
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
            Debug.Log("toOptions = true");
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
            Debug.Log("toMainMenu = true");
        }
    }
}
