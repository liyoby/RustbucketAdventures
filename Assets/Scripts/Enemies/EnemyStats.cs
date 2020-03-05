using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int health = 100;        //Enemy Health field
    public int currentHealth;

    DropIt enemyDrops;


    void Start()
    {
        enemyDrops = GetComponent<DropIt>();
        currentHealth = health;
    }

    void Update()
    {
        death();
    }


    void destroyEnemy()
    {
        Destroy(gameObject);
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void death()
    {
        if (currentHealth <= 0)
        {
            enemyDrops.dropIt();
            destroyEnemy();
        }
            //anim.setTrigger("Death");
            //Call function to drop health (wrench)
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ElectroBall"))
        {
            takeDamage(25);
        }

    }

}
