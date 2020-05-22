using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public float currentHealth;
    public float delayTimer;          //time before DeathSequence is called
    public float deathTimer;            //time before LevelRestart is called
    public bool isDead;
    public bool hasPlayed;              //if death sound has played
    public Canvas deathCanvas;          //deathsplash screen
    Scene currentLevel;
    public PlayerController playerController;
    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        delayTimer = 2.25f;
        deathTimer = 5f + delayTimer;
        currentHealth = health;
        deathCanvas.enabled = false;
        currentLevel = SceneManager.GetActiveScene();
        audioManager = FindObjectOfType<AudioManager>();
        hasPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //checks if player is dead
        if (currentHealth <= 0)
        {
            audioManager.StopSound("Theme");
            
            //call death sequence once and after a delay
            if (!isDead) 
            {
                delayTimer -= Time.deltaTime;

                playerController.AnimateDeath();

                if(!hasPlayed)
                {
                    audioManager.PlaySound("PlayerDeath");
                    hasPlayed = true;
                }

                if (delayTimer <= 0)
                {
                    DeathSequence();
                }
            }

            //countdown for time viewing splashscreen
            deathTimer -= Time.deltaTime;

            //when time is elapsed restart level
            if (deathTimer <= 0)
            {
                //currently restarts level
                //will need to hook up to checkpoint system later
                RestartLevel();
            }
        }
    }
 
    public void AddHealth(int pickup)
    {
        currentHealth += pickup;
        audioManager.PlaySound("PlayerHeal");
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void DeathSequence()
    {
        isDead = true;
        deathCanvas.enabled = true;
    }

    //temporary code for testing
    //will be replaced with checkpoint call
    public void RestartLevel()
    {
        SceneManager.LoadScene(currentLevel.name);
        FindObjectOfType<AudioManager>().PlaySound("Theme");
    }

}