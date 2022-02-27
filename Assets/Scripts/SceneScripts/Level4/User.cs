using Assets.Scripts.SceneScripts.Level4;
using Assets.Scripts.SceneScripts.Level5;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public LayerMask groundLayer;
    public GameObject level;
    public float jumpHeightVelocity = 7.5f;


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
        var cc = FindObjectOfType<CustomController>();
        if (cc.blue.isActive || cc.green.isActive)
        {
            xInput = 0;
            if (cc.blue.isActive) xInput += 1;
            if (cc.green.isActive) xInput -= 1;
        }

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
        var yInput = Input.GetAxisRaw("Vertical");
        if (cc.yellow.isActive) yInput = 1;

        if ( yInput > 0 && IsGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpHeightVelocity);
        }

        if(transform.position.y < -5)
        {
            var lvl = level.GetComponent<LevelState>();
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
        float distance = 0.5f;

        Debug.DrawRay(position, direction, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
}
