using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask groundLayer;
    public float jumpForce = 6.0f;
    public float speed = 5.0f;
    //public float coyoteTime;
    //public float jumpDamping;
    public Vector2 currentVelocity;
    //public Animator anim;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRend;

    private BoxCollider2D boxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        //gives player physical components like gravity
        rb = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        //finds x and y axis of player
        float horizontalInput = Input.GetAxis("Horizontal");

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

    bool CheckGround()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float rotation = 0f;
        float distance = 2.0f;

        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, rotation, direction, distance, groundLayer);
        if(hit.collider != null)
        {
            return true;
        }
        return false;
    }
}
