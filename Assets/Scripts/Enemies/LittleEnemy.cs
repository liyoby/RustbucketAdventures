using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Quick way to tell big enemy stats vs little enemy stats
 * Used to trigger unique animation (stagger)
 */

public class LittleEnemy : MonoBehaviour
{
    public int health = 100;        //Enemy Health field
    public int currentHealth;
    public Animator anim;
    DropIt enemyDrops;
    public float delayTimer;
    public bool hasPlayed;              //if death sound has played
    public AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        anim = gameObject.GetComponent<Animator>();
        enemyDrops = GetComponent<DropIt>();
        currentHealth = health;
        delayTimer = 2.75f;
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
        anim.SetTrigger("Stagger");
    }

    public void death()
    {

        if (currentHealth <= 0)
        {
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
