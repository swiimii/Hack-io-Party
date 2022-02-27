using Assets.Scripts.SceneScripts.Level4;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public LayerMask groundLayer;
    public GameObject level;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var body = GetComponent<Rigidbody2D>();

        // Horizontal movement
        var xInput = Input.GetAxisRaw("Horizontal");

        if (xInput != 0)
        {
            var xVelocity = body.velocity.x + xInput * 0.25f;
            if(xVelocity > 3)
            {
                xVelocity = 3f;
            }
            else if(xVelocity < -3)
            {
                xVelocity = -3f;
            }

            body.velocity = new Vector2(xVelocity, body.velocity.y);
        }

        // Jumping
        if(Input.GetAxisRaw("Vertical") > 0 && IsGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, 7.5f);
        }

        if(transform.position.y < -5)
        {
            var lvl = level.GetComponent<Level4>();
            if (!lvl.isWon)
            {
                lvl.FailLevel();
            }

        }
    }

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 0.75f;

        Debug.DrawRay(position, direction, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
}
