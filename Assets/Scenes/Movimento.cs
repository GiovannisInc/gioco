using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movimento : MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField]
    float movespeed = 3f;

    [SerializeField]
    float speedJump = 2f;

    bool isJumping = false;
    
    

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Movement();
        Jump();
        Scatto();
    }
    void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(Vector2.right.x * movespeed * h, body.velocity.y);
        body.velocity = direction;

        if(direction.x < 0)
        {
            body.transform.localScale = new Vector3(-0.08739962f, 0.08589447f, 0.100344f);
            
            
        }
        else if(direction.x > 0)
        {
            body.transform.localScale = new Vector3(0.08739962f, 0.08589447f, 0.100344f);
           
        }
    }

    void Jump()
    {
        float j= Input.GetAxis("Jump");

        if (isJumping)
        {
            if (body.velocity.y == 0)
            {
                isJumping = false;
            }
           
        }
       
        else 
        {
            if (j > 0)
            {
                body.AddForce(Vector2.up * speedJump, ForceMode2D.Impulse);
                isJumping = true;

            }
        }
    }
    void Scatto()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movespeed = 1.5f * movespeed;
            
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movespeed = movespeed/1.5f;
           
        }

    }
}

