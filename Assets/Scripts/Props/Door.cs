using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public SpriteRenderer spriteRend;
    public Sprite openSprite;
    public Sprite closedSprite;
    public bool isPowered;
    public float doorTimer;
    public float doorReset;
    public BoxCollider2D doorCollider;
    public bool isPlaying;
    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        doorCollider = GetComponent<BoxCollider2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        spriteRend.sprite = closedSprite;
        isPowered = false;
        doorReset = 5f;
        doorTimer = doorReset;
        isPlaying = false;
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        doorTimer -= Time.deltaTime;

        if (isPowered == true && doorTimer > 0)
        {
            spriteRend.sprite = openSprite;
            doorCollider.enabled = false;

            if (!isPlaying)
            {
                audioManager.PlaySound("Timer");
            }
        }

        else
        {
            doorCollider.enabled = true;
            spriteRend.sprite = closedSprite;

            audioManager.StopSound("Timer");
        }
    }
}
