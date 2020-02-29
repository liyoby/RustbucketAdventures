using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerBox : MonoBehaviour
{

    public bool powered = false;

    public GameObject bBox;

    ConveyorBeltMovement conveyorMove;

    // Update is called once per frame
    void Update()
    {
        if (powered)
        {
            conveyorMove.UpdateIdle();
        }
    }
    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Electro Ball"))
        {
            powered = true;
        }

    }
}
