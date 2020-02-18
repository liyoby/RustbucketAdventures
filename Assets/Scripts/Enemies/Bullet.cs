using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    public bool inRange = false;

    public Transform pathStart,          //Assign gameObjs to these variables for manipulation
                     pathEnd;

    private Transform path;
    private Vector2 target;

    void Start()
    {
        path = GameObject.FindGameObjectWithTag("Path End").transform;

        target = new Vector2(path.position.x, path.position.y);
    }

    void Update()
    {

        if (playerInRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            destroyBullet();
        }

    }

    public bool playerInRange()
    {
        return (inRange = Physics2D.Linecast(pathStart.position, pathEnd.position, 1 << LayerMask.NameToLayer("Player")));
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