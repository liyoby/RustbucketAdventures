﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public PlayerHealth PlayerHp;
  
    void OnTriggerEnter2d(Collider2D other)
    {
       
            if(other.CompareTag("Player"))
            {
                PlayerHp.currentHealth = 0;
            }
        
    }
}
