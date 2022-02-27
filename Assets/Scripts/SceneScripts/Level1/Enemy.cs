using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int direction;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        //var randDirection = Random.Range(0, 100);
        //direction = Random.value > 0.5 ? -1 : 1;
        direction = 1;

        transform.Translate(new Vector3(-10 * direction, 0));

        speed = Random.Range(1, 10);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(new Vector2(direction * speed * 0.5f * Time.deltaTime, 0));
        if (IsOutOfScreenspace())
        {
            transform.Translate(new Vector2(-20, 0));
            speed = Random.Range(1, 10);
        }
    }

    public void SetRow(int row)
    {
        transform.Translate(new Vector2(0, 100*row));
    }

    public bool IsOutOfScreenspace()
    {
        var xpos = transform.position.x;
        if(direction == 1)
        {
            return xpos > 10;
        }
        else
        {
            return xpos < 10;
        }
    }
}
