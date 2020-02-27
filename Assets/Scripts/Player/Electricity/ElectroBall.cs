using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroBall : MonoBehaviour
{
    public float timerTilDestroy;           //lifetime of electroball

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        //if hits Enemy
        if(other.CompareTag("Enemy"))
        {
            //call damage enemy

            //then call destory
            DestroyElectroBall();
        }
        //if hits breakerbox
        else if(other.CompareTag("BreakerBox"))
        {
            //call affect breaker box

            //then call destory
            DestroyElectroBall();
        }
        else
        {
            DestroyElectroBall();
        }
    }
}
