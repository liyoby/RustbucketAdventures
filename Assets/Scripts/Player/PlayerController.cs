using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask groundLayer;
    public float jumpForce;
    public float speed;
    //public float coyoteTime;
    //public float jumpDamping;
    public Vector2 currentVelocity;
    //public Animator anim;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRend;
    public bool isFacingRight;
    private BoxCollider2D boxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        //gives player physical components like gravity
        rb = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        isFacingRight = true;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        //finds x and y axis of player
        float horizontalInput = Input.GetAxis("Horizontal");

        //change sprite direction on x axis
        if(horizontalInput > 0 && !isFacingRight)
        {
            //send turn as 0
            float y = 0;
            FlipPlayer(y);
        }

        else if (horizontalInput < 0 && isFacingRight)
        {
            //send turn as 180
            float y = 180;
            FlipPlayer(y);
        }

        //controls player speed
        float velocity = horizontalInput * speed;
        rb.velocity = Vector2.SmoothDamp(rb.velocity, new Vector2(velocity, rb.velocity.y), 
            ref currentVelocity, 0.02f);

        //add coyote time later
        if (Input.GetButtonDown("Jump") && CheckGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void FlipPlayer(float y)
    {
        //set bool to opposite
        isFacingRight = !isFacingRight;

        //Euler angle used to ensure shoot raycast flips with player
        transform.eulerAngles = new Vector3(0, y, 0);
      
    }

    bool CheckGround()
    {
        Vector2 direction = Vector2.down;
        float rotation = 0f;
        float distance = 1.0f;

        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 
            rotation, direction, distance, groundLayer);

        if(hit.collider != null)
        {
            return true;
        }
        return false;
    }
}
