using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroBall : MonoBehaviour
{
    public float timerTilDestroy;           //lifetime of electroball
    public float speed;                     //electroball speed
    public Rigidbody2D rb;

    void Start()
    {
        //controls movement of electroball
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        //controls lifetime
        timerTilDestroy -= Time.deltaTime;

        if(timerTilDestroy <= 0)
        {
            DestroyElectroBall();
        }
    }

    void DestroyElectroBall()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("BreakerBox"))
        {
            Debug.Log("Breaker box hit!");

            //call affect breaker box
        }

        //destroy on collision unless colliding with player
        if (!other.CompareTag("Player"))
        {
            DestroyElectroBall();
        }
        
    }
}
