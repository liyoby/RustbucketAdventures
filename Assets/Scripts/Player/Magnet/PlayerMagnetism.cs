using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnetism : MonoBehaviour
{
    public float maxMagnetCharge;
    public float currentMagnetCharge;
    public float lostCharge;
    public GameObject crossHairs;
    public SpriteRenderer spriteRend;
    public PlayerController playerController;
   
    // Start is called before the first frame update
    void Start()
    {
        
        maxMagnetCharge = 100;
        currentMagnetCharge = maxMagnetCharge;
        spriteRend.enabled = false;
        lostCharge = 25;
    }

    // Update is called once per frame
    void Update()
    {
        //needs a get button hold?
        if (Input.GetButton("Magnetism") && currentMagnetCharge >= 25)
        {
            //Debug.Log("Down");
            //show crosshairs 
            spriteRend.enabled = true;
            playerController.AnimateAim();
        }

        //check button release
        if (Input.GetButtonUp("Magnetism") && currentMagnetCharge >= 25)
        {
            //Debug.Log("Up");
            spriteRend.enabled = false;
            ReduceCharge();
            playerController.AnimateShoot();
        }

    }

    public void RefillCharge()
    {
        currentMagnetCharge = maxMagnetCharge;
    }

    public void ReduceCharge()
    {
        currentMagnetCharge -= lostCharge;
    }
}
