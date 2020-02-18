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
        patrol,
        idle
    }

    public States state = States.idle;

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

            case States.patrol:
                UpdatePatrol();
                break;
        }
    }

    void UpdateIdle()
    {
        if (Input.GetButtonDown("Jump"))    ///Change this to if player touches conveyor belt.
        {
            state = States.patrol;
        }
    }

    void UpdatePatrol()
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
}
