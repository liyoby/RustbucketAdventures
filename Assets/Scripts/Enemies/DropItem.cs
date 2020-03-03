using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    private Transform powerUp;
    private Transform lastPos;

    private Vector2 target;
    
    GameObject player;

    PlayerHealth playerHealth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

        powerUp = GameObject.FindGameObjectWithTag("Enemy").transform; //where to b

        lastPos = powerUp;
        target = new Vector2(lastPos.position.x, lastPos.position.y);
    }

    void Update()
    {
        destroyDrop();
    }

    void destroyDrop()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Health Hit");
            playerHealth.AddHealth(15);
            destroyDrop();
        }

    }

}
