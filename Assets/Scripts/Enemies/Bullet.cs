﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    private Transform EOL;
    private Vector2 target;

    void Start()
    {
        EOL = GameObject.FindGameObjectWithTag("Path End").transform;

        target = new Vector2(EOL.position.x, EOL.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            destroyBullet();
        }
    }

    void destroyBullet()
    {
        Destroy(gameObject);
    }

   void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            destroyBullet();
        }

    }
}
