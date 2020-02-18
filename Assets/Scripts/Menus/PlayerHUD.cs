using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHUD : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Image healthBar;
    public Image chargeBar;
   
    public int magnetCharge = 100;

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = playerHealth.currentHealth / 100;
        chargeBar.fillAmount = magnetCharge / 100;
    }
   
}

