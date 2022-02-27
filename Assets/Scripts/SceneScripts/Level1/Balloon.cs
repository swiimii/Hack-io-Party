using Assets.Scripts.SceneScripts.Level1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public GameObject level;
    private bool _dead = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Check if failed
        var lvl = level.GetComponent<BalloonLevel>();
        if (lvl.isFailed)
        {
            _dead = true;
        }

        // Process Movement
        if (transform.position.y < 12) 
        {
            if (!_dead)
            {
                var input = Input.GetAxisRaw("Vertical");
                var cc = FindObjectOfType<CustomController>();
                if (cc.green.isActive || cc.red.isActive)
                {
                    input = 0f;
                    if (cc.green.isActive) input += 1;
                    if (cc.red.isActive) input -= 1;
                }
                transform.Translate(new Vector3(0, input * 3 * Time.deltaTime));

            }
            else
            {
                transform.Translate(Vector2.down * 4 * Time.deltaTime);
            }
        }
        else
        {
            transform.Translate(Vector2.up * 4 * Time.deltaTime);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    public void Die()
    {
        // Animate death here :)

        _dead = true;
        var lvl = level.GetComponent<BalloonLevel>();
        lvl.FailLevel();
    }
}
