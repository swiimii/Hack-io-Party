using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.y < 12) 
        {
            var input = Input.GetAxisRaw("Vertical") * 3 * Time.deltaTime;
            transform.Translate(new Vector3(0, input));
        }
        else
        {
            transform.Translate(new Vector3(0, 0.05f));
        }

    }
}
