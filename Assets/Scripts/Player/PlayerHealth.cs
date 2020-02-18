using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddHealth(int pickup)
    {
        currentHealth += pickup;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

}
