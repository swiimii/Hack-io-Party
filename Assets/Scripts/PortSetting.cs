using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortSetting : MonoBehaviour
{
    public Text userInput, previewText;
    void Start()
    {
        if (!PlayerPrefs.HasKey("Port"))
        {
            PlayerPrefs.SetString("Port", "COM3");
            PlayerPrefs.Save();
        }
        previewText.text = PlayerPrefs.GetString("Port", "COM3");
    }

    public void SaveSettings()
    {
        if (userInput.text != "")
        {
            PlayerPrefs.SetString("Port", userInput.text);
            PlayerPrefs.Save();
            previewText.text = userInput.text.Trim();
            userInput.text = "";
        }
    }
}
