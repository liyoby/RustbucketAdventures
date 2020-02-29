using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltMovement : MonoBehaviour
{
    public List<Transform> nodes;
    public int nodeIndex = 0;
    public float speed = 1.0f;

    public enum States
    {
        active,
        idle
    }

    public States state = States.idle;

    Collider player;
    BreakerBox bBox;


    void Start()
    {

    }

    void Update()
    {
        switch (state)
        {
            case States.idle:
                UpdateIdle();
                break;

            case States.active:
                UpdateActive();
                break;
        }
    }

    public void UpdateIdle()
    {
            state = States.active;
    }

    void UpdateActive()
    {
        transform.position = Vector3.Lerp(transform.position,
                                          nodes[nodeIndex].transform.position,
                                          speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, nodes[nodeIndex].transform.position) < 2)
        {
            nodeIndex++;

            if (nodeIndex >= nodes.Count)
            {
                nodeIndex = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UpdateIdle();
        }

    }

}
