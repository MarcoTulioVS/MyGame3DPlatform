using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkEyeHit : EnemyWeapon
{
    public PinkEye pinkEye;
    public override void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pinkEye.Attack(true);
        }
        
    }

    public override void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pinkEye.Attack(false);
        }
    }
}
