using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagStation : MonoBehaviour
{
    public PlayerMagnetism playerMag;

    void OnEnterTrigger2D()
    {
        FindObjectOfType<AudioManager>().PlaySound("MagnetRecharge");
        playerMag.RefillCharge();
    }
}
