using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class CustomController : MonoBehaviour
{
    // change your serial port
    public string port = "COM3";
    SerialPort sp;

    public SerialState red, green, yellow, blue, motion;

    private void Start()
    {
        sp = new SerialPort(port, 9600);
        try
        {
            sp.Open();
            sp.ReadTimeout = 100; // In my case, 100 was a good amount to allow quite smooth transition. 
        }
        catch (System.Exception)
        {
            Debug.Log("Custom controller not connected on " + port);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                int input = sp.ReadByte();
                motion.SetState((input & 1) != 0);
                blue.SetState((input & 2) != 0);
                yellow.SetState((input & 4) != 0);
                green.SetState((input & 8) != 0);
                red.SetState((input & 16) != 0);
            }
            catch (System.Exception)
            {

            }
        }
    }
}
