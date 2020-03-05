using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropIt : MonoBehaviour
{
    public GameObject drop;

    GameObject enemy;
    EnemyStats enemyHealth;


    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyHealth = enemy.GetComponent<EnemyStats>();
    }

    public void dropIt()
    {
        Instantiate(drop, transform.position, Quaternion.identity);
    }


}
