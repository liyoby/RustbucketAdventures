using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroShoot : MonoBehaviour
{
    public GameObject electroBall;          //projectile
    public float timerBtwShots;             //timer for shots
    public float shotTime;                  //timer's reset value

    // Start is called before the first frame update
    void Start()
    {
        //set to 0 intially so player can immediately shoot
        timerBtwShots = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Electricity") && timerBtwShots <= 0)
        {
            ShootElectricity();
            timerBtwShots = shotTime;
        }
        else
        {
            timerBtwShots -= Time.deltaTime;
        }
    }

    public void ShootElectricity()
    {
        Instantiate(electroBall, transform.position, Quaternion.identity);
    }
}
