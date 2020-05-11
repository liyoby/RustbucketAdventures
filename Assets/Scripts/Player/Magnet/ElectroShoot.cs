using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroShoot : MonoBehaviour
{
    public GameObject electroBall;          //projectile
    public Transform magnetTip;             //where electroball spawns
    private float timerBtwShots;             //timer for shots
    public float shotTime;                  //timer's reset value
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float zRotation = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, zRotation);

        if (Input.GetButtonDown("Electricity") && timerBtwShots <= 0)
        {
            playerController.AnimateAim();
            ShootElectricity();
            timerBtwShots = shotTime;
            playerController.AnimateShoot();
        }
        else
        {
            timerBtwShots -= Time.deltaTime;
        }
    }

    public void ShootElectricity()
    {
        Instantiate(electroBall, magnetTip.position, magnetTip.rotation);
    }
}
