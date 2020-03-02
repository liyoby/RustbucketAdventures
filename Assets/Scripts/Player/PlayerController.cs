using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerHealth playerHP;

    public LayerMask groundLayer;
    public LayerMask enemyLayer;
    public Vector2 currentVelocity;

    public Rigidbody2D rb;
    public SpriteRenderer spriteRend;
    public BoxCollider2D boxCollider2D;
    //public Animator anim;

    public float jumpForce;
    public float speed;
    //public float coyoteTime;
    //public float jumpDamping;
    public float iFrameTimer;           //temporary invincibility after taking damage
    public float iFrameReset;           //reset timer to this value
   
    public bool isFacingRight;
   

    // Start is called before the first frame update
    void Start()
    {
        //gives player physical components like gravity
        rb = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        isFacingRight = true;
        iFrameTimer = 0f;
        
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

        //if player is stopped, check for bump
        if(velocity == 0 && iFrameTimer <= 0)
        {
            //if bumped is true, reset timer
            if(CheckEnemyBump())
            {
                iFrameTimer = iFrameReset;
            }
        }

        iFrameTimer -= Time.deltaTime;

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

    //Note! Collider only seems to register bullet damage
    //alternate method had to be used for contact damage
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("Bit the bullet!");
            playerHP.TakeDamage(25);
        }
    }

    bool CheckEnemyBump()
    {
        Vector2 down = Vector2.down;
        Vector2 left = Vector2.left;
        Vector2 right = Vector2.right;
        float rotation = 0f;
        float distance = 0.01f;

        RaycastHit2D hitDown = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size,
            rotation, down, distance, enemyLayer);

        RaycastHit2D hitLeft = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size,
            rotation, left, distance, enemyLayer);

        RaycastHit2D hitRight = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size,
            rotation, right, distance, enemyLayer);

        //if any side is hit == true and player takes damage
        if (hitDown.collider != null || hitLeft.collider != null || hitLeft.collider != null)
        {
            Debug.Log("He's touching me!");
            playerHP.TakeDamage(25);
           
            return true;
        }
        return false;
    }

}
