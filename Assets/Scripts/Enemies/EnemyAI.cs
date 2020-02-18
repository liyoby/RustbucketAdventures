using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private Rigidbody2D rb;          //Enemy rigidbody
    public float speed = 1.0f;      //Set speed of chase 
    
    public bool spotPlayer = false; //spotPlayer default false 

    public Transform target;        //Player is target 
    public Transform[] nodes;       //Set Position For Enemy to return to / Controls Patrol Points
    public Transform eyes,          //Assign gameObjs to these variables for manipulation
                     eyeRange;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
   
    }

    void Update()
    {
        sensePlayer();      //Function Sense Player in range
        playerAbove();      //Check if player landed on spikes on enemy head
        chase();            //Chase player when sensePlayer is true
    }

    public bool sensePlayer()
    {
        //Draw Line for Programmer Reference (Does not show up in Game window)
        Debug.DrawLine(eyes.position, eyeRange.position, Color.cyan);   
        //spotPlayer "sees" player when true (start, end, object/item)
        return (spotPlayer = Physics2D.Linecast(eyes.position, eyeRange.position, 1 << LayerMask.NameToLayer("Player")));
    }

    bool playerAbove()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.up;
        float distance = 0.5f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, 1 << LayerMask.NameToLayer("Player"));   //change ground layer to player layer
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

    void chase()
    {
        //The moment the enemy can "see" the player, trigger enemy chase
        if(spotPlayer == true)
        {
            //Chase the player
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }


}
