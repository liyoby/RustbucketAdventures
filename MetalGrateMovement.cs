using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalGrateMovement : MonoBehaviour
{

    public float timeTweenShots;
    public float startTime;

    public string BreakBoxTag;

    private Transform eBall;
    private Transform brBox;
    private Vector2 target;

    public GameObject grate;
    public GameObject bBox;


    void Start()
    {
        eBall = GameObject.FindGameObjectWithTag("Electro Ball").transform;
        brBox = GameObject.FindGameObjectWithTag(BreakBoxTag).transform;

        target = new Vector2(eBall.position.x, eBall.position.y);

        timeTweenShots = startTime; //At start, set start time to count down from.
    }

    void Update()
    {
        if (brBox.position.x == target.x && brBox.position.y == target.y)
        {
            moveGrate();
        }
    }

    public void moveGrate()
    {
        if (timeTweenShots <= 0)
        {
            Instantiate(grate, transform.position, Quaternion.identity);
            timeTweenShots = startTime;   //Reset time between shots to a set start time.
        }
        else
        {
            //Ticks down time between shots.  Enemy shoots on 0.
            timeTweenShots -= Time.deltaTime;
        }
    }


}
