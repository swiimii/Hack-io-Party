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
        var input = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        transform.Translate(new Vector3(0, input));

    }
}
