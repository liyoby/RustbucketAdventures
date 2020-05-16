using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalGrate : MonoBehaviour
{

    public float speed;

    public string pathTag;

    private Transform grate;
    private Vector2 target;

    void Start()
    {
        grate = GameObject.FindGameObjectWithTag(pathTag).transform;

        target = new Vector2(grate.position.x, grate.position.y);
    }

    public void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            destroyGrate();
        }
    }

    void destroyGrate()
    {
        Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            destroyGrate();
        }

    }
}