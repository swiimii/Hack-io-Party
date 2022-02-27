using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : LevelState
{
    public GameObject trafficOff;
    public GameObject trafficRed;
    public GameObject trafficYellow;
    public GameObject trafficGreen;
    public GameObject car;
    public GameObject explosion;
    public Transform carTarget;

    public float length = 10;
    private int trafficState = 3; //3 Green, 2 Yellow, 1 Red, 0 Off

    private float time;
    private float carStep;

    public override bool IsAtTargetState()
    {
        throw new System.NotImplementedException();
    }

    protected override void Start()
    {
        base.Start();
        time = Time.time;
        carStep = (car.transform.position - carTarget.position).x / length * 3; //need to use something like this for car transform scaling
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFailed || !isWon)
        {
            if(trafficState > 0)
            {
                // TODO: Make the car transform scale with `float length`
                car.transform.position = Vector3.MoveTowards(car.transform.position, carTarget.position, 300 * Time.deltaTime);
            }
            if (Time.time - time > length) // Time for one light exceeded; change light
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
                            //explosion noise here
                            explosion.transform.position = new Vector3(car.transform.position.x, explosion.transform.position.y, explosion.transform.position.z);
                            break;
                    }

                    // play beep noise here
                    time = Time.time;
                }
                else
                {
                    if (!isWon) // Activate before red light; lose
                    {
                        FailLevel();
                    }
                }
            }
            if (trafficState == 1 && Input.GetKeyDown(KeyCode.Space)) // Activate on red light; win
            {
                if (!isFailed)
                {
                    WinLevel();
                    StartCoroutine(StartRandomLevel());
                }
            }
            else if (trafficState != 1 && Input.GetKeyDown(KeyCode.Space)) // Activate after red light; lose
            {
                if (!isWon)
                {
                    FailLevel();
                }
            }
        }
    }
}
