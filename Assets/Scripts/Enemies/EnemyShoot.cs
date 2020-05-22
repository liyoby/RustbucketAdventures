﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float nearEnemyDistance;
    public float timeTweenShots;
    public float startTime;
    public Animator anim;
    public AudioManager audioManager;

    public GameObject bullet;

    public Transform target;

    EnemyStats enemy;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        anim = gameObject.GetComponent<Animator>();
        enemy = GetComponent<EnemyStats>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        timeTweenShots = startTime; //At start, set start time to count down from.
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < nearEnemyDistance)
        {
            shootBullet();
        }
        else
        {
            anim.SetBool("InRange", false);
        }
    }

    void shootBullet()
    {
        if (timeTweenShots <= 0)
        {
            audioManager.PlaySound("EnemyShoot");
            anim.SetBool("InRange", true);
            Instantiate(bullet, transform.position, Quaternion.identity);
            timeTweenShots = startTime;   //Reset time between shots to a set start time.
        }
        else
        {
            //Ticks down time between shots.  Enemy shoots on 0.
            timeTweenShots -= Time.deltaTime;
            
        }
    }


   
}
