using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach to Metal Grates that are going to move
//Motion currently is back and forth, but still can be used for trickier aiming purposes
//Needs two nodes per Metal Grate
//Place at ends of conveyor belts a little above the surface

public class MetalGrateMove : MonoBehaviour
{
    public List<Transform> nodes;
    public int nodeIndex = 0;
    public float speed = 1.0f;

    public enum States
    {
        patrol,
        idle,
    }

    public States state = States.idle;

    void Start()
    {
        //Trying to start in idle
        state = States.idle;
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

    public void UpdateIdle()
    {
        state = States.patrol;
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
