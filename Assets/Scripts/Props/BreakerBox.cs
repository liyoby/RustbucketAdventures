using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach to Breaker Box Object

public class BreakerBox : MonoBehaviour
{

    public bool powered = false;


    MetalGrateMove grateMove;

    // Update is called once per frame
    void Update()
    {
        if (powered)
        {
            grateMove.UpdateIdle();
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
