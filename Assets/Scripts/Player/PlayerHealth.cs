using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public int currentHealth;
    //public float delayTimer;          //time before DeathSequence is called
    public float deathTimer;            //time before LevelRestart is called
    public bool isDead;
    public Canvas deathCanvas;          //deathsplash screen
    Scene currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        // delayTimer = 2f;
        deathTimer = 5f; //+ delayTimer;
        currentHealth = health;
        deathCanvas.enabled = false;
        currentLevel = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        //checks if player is dead
        if (currentHealth <= 0)
        {
            //delayTimer -= Time.deltaTime;
            //call death sequence once and after a delay
            if (!isDead)// && delayTimer <= 0)
            {
                DeathSequence();
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
    }

}