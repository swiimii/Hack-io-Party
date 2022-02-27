using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject trafficOff;
    public GameObject trafficRed;
    public GameObject trafficYellow;
    public GameObject trafficGreen;
    public GameObject level;

    public float length = 10;
    public int trafficState = 3; //3 Green, 2 Yellow, 1 Red, 0 Off

    private float time;

    private void Start()
    {
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - time  > length)
        {
            if (trafficState > 0)
            {
                trafficState -= 1;
                switch (trafficState)
                {
                    case 3:
                        trafficYellow.SetActive(true);
                        break;
                    case 2:
                        trafficYellow.SetActive(true);
                        break;
                    case 1:
                        trafficRed.SetActive(true);
                        break;
                    case 0:
                        trafficOff.SetActive(true);
                        break;
                }
                
                // play beep noise
                time = Time.time;
            }
            else
            {
                //lose
                Debug.Log("lose");
            }
        }
        if(trafficState == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            //win
            Debug.Log("win");
        }
    }
}
