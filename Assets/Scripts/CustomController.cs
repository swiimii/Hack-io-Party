using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class CustomController : MonoBehaviour
{
    // change your serial port
    SerialPort sp = new SerialPort("COM3", 9600);

    public bool red, green, yellow, blue, motion;

    // Update is called once per frame
    void Update()
    {
        if (!sp.IsOpen)
        {
            sp.Open();
            sp.ReadTimeout = 100; // In my case, 100 was a good amount to allow quite smooth transition. 
        }
        else
        {
            try
            {
                int input = sp.ReadByte();
                motion = (input & 1) != 0;
                blue = (input & 2) != 0;
                yellow = (input & 4) != 0;
                green = (input & 8) != 0;
                red = (input & 16) != 0;
            }
            catch (System.Exception)
            {

            }
        }
    }
}
