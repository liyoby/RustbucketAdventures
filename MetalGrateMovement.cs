using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalGrateMovement : MonoBehaviour
{

    public float timeTweenShots;
    public float startTime;

    string eBall = "Electro Ball";

    public GameObject grate;
    public GameObject bBox;


    void Start()
    {
        timeTweenShots = startTime; //At start, set start time to count down from.
    }

    void Update()
    {
        moveGrate();
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

    void OnTriggerEnter2d(Collider2D bBox)
    {
        if (bBox.CompareTag(eBall))
        {
            moveGrate();
        }
    }
}
