﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DropItem : MonoBehaviour
{
    public float speed;
    private Transform player;

    private Vector2 target;

    GameObject pl;

    PlayerHealth playerHealth;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);

        pl = GameObject.FindGameObjectWithTag("Player");
        playerHealth = pl.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            destroyDrop();
        }
    }

    void destroyDrop()
    {
        Destroy(gameObject, 4.0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            destroyDrop();
            playerHealth.AddHealth(25); //Cap Health
        }

    }

}







