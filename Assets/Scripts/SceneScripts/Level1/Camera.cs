using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        var input = Input.GetAxisRaw("Vertical");
        if (FindObjectOfType<CustomController>().green.isActive)
        {
            input = 1;
        }
        if (FindObjectOfType<CustomController>().red.isActive)
        {
            input = Mathf.Max(input - 1, -1);
        }

        transform.Translate(new Vector3(0, input * 2 * Time.deltaTime));

    }
}
