using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerBox2 : MonoBehaviour
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
        if (MetalGrateMovement2.isPowered == true)
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
            if (MetalGrateMovement2.isPowered == false)
            {
                FindObjectOfType<AudioManager>().PlaySound("PowerSwitch");
                MetalGrateMovement2.isPowered = true;
            }

        }

    }
}
