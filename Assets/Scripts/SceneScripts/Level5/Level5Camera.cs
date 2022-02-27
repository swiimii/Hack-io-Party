using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Camera : MonoBehaviour
{
    public GameObject user;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var userPosition = user.GetComponent<User>().transform.position;

        if (userPosition != transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(userPosition.x, userPosition.y, transform.position.z), 1.0f);

        }

    }
}
