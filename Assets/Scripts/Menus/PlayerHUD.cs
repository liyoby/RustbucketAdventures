using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHUD : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerMagnetism playerMagnetism;
    public Image healthBar;
    public Image chargeBar;

    void Update()
    {
        healthBar.fillAmount = playerHealth.currentHealth / 100;
        chargeBar.fillAmount = playerMagnetism.currentMagnetCharge / 100;
    }
   
}

