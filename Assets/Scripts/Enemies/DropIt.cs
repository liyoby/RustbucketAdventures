using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropIt : MonoBehaviour
{
    public GameObject dropFab;

    GameObject enemy;
    EnemyStats enemyHealth;

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyHealth = enemy.GetComponent<EnemyStats>();
    }

    void Update()
    {
        dropIt();
    }

    void dropIt()
    {
        Instantiate(dropFab, transform.position, Quaternion.identity);
    }


}
