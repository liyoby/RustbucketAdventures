﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach to Last Room
public class BreakerBox3 : MonoBehaviour
{
    public SpriteRenderer spriteRend;
    public Sprite onSprite;
    public Sprite offSprite;

    void start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        spriteRend.sprite = offSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (MetalGrateMovement3.isPowered == true)
        {
            spriteRend.sprite = onSprite;
        }

        else
        {
            spriteRend.sprite = offSprite;
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ElectroBall"))
        {
            if (MetalGrateMovement3.isPowered == false)
            {
                FindObjectOfType<AudioManager>().PlaySound("PowerSwitch");
                MetalGrateMovement3.isPowered = true;
            }

        }

    }
}