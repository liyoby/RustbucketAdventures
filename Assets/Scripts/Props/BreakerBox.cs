using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach to Breaker Box Object

public class BreakerBox : MonoBehaviour
{

    public bool powered = false;

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ElectroBall"))
        {
            if (MetalGrateMovement.isPowered == false)
            {
                FindObjectOfType<AudioManager>().PlaySound("PowerSwitch");
                MetalGrateMovement.isPowered = true;
            }
        }

    }
}
