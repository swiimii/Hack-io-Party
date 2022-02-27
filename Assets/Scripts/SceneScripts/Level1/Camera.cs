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

        var input = Input.GetAxisRaw("Vertical") * 2 * Time.deltaTime;
        transform.Translate(new Vector3(0, input));

    }
}
