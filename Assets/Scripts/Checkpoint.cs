using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameManager gm;


    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D check)
    {
        if(check.CompareTag("Player"))
        {
            gm.lastCheckpoint = transform.position;
        }
    }
}
