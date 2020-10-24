using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    bool jump;
    Rigidbody2D rb;
    public Vector2 bounds= new Vector2(-500,500); //storing in Vector2 instead of keeping 2 variables to clamp horizontal position
    public Vector2 jumpForce = new Vector2(0,500);

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    private void Update()
    {
        jump = Input.GetButtonDown("Fire1");
        if (jump)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(jumpForce.x*GameManager.direction,jumpForce.y));
        }
       
    }
    private void FixedUpdate()
    {
        if (transform.position.x > bounds.y)
        {
            rb.position = new Vector2(bounds.x,rb.position.y);
        }
        else if (transform.position.x<bounds.x)
        {
            rb.position = new Vector2(bounds.y, rb.position.y);
        }
    }
    
}
