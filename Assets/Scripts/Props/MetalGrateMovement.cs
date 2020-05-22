﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalGrateMovement : MonoBehaviour
{

    public float timeTweenGrates;
    public float startTime;

    public string BreakBoxTag;

    public static bool isPowered;

    public GameObject grate;
    GameObject bBox;

    void Start()
    {
        isPowered = false;
        bBox = GameObject.FindGameObjectWithTag(BreakBoxTag);
        timeTweenGrates = startTime; //At start, set start time to count down from.
    }

    void Update()
    {
        if (isPowered == true)
        {
            moveGrate();
        }
    }

    public void moveGrate()
    {
        if (timeTweenGrates <= 0)
        {
            Instantiate(grate, transform.position, Quaternion.identity);
            timeTweenGrates = startTime;   //Reset time between shots to a set start time.
        }
        else
        {
            //Ticks down time between shots.  Enemy shoots on 0.
            timeTweenGrates -= Time.deltaTime;
        }
    }
}