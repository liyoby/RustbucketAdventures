using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int health = 100;        //Enemy Health field
    public int currentHealth;
    public Animator anim;
    EnemyAI enemy;
    DropIt enemyDrops;
    public float delayTimer;
    public bool hasPlayed;              //if death sound has played
    public AudioManager audioManager;


    void Start()
    {
        enemy = GetComponent<EnemyAI>();
        audioManager = FindObjectOfType<AudioManager>();
        anim = gameObject.GetComponent<Animator>();
        enemyDrops = GetComponent<DropIt>();
        currentHealth = health;
        delayTimer = 2.5f;
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
            enemy.stopPatrol();
            delayTimer -= Time.deltaTime;
            AnimateDeath();

            if (!hasPlayed)
            {
                audioManager.PlaySound("EnemyDeath");
                hasPlayed = true;
            }

            if (delayTimer <= 0)
            {
                enemyDrops.dropIt();
                destroyEnemy();
            }
        }
            
            //Call function to drop health (wrench)
    }

    public void AnimateDeath()
    {
        anim.SetTrigger("Dead");
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ElectroBall"))
        {
            takeDamage(25);
        }

    }

}
