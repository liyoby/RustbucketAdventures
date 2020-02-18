using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int speed = 1;       //Speed of Weapon ammo field
    public int health = 100;    //Enemy Health field

    public Transform target;    //Player is target
    //public Transform weapon;    //Enemy weapon


    void Update()
    {

    }

    void death()
    {
        if (health <= 0)
        {
            //anim.setTrigger("Death");
            //Destroy
        }
    }

}
