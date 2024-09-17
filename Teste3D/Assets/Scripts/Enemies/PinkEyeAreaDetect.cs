using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkEyeAreaDetect
{
    public PinkEye pinkEye;
    public void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pinkEye.Attack(true);
            pinkEye.lookAtTarget = true;
        }
        
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pinkEye.Attack(false);
            pinkEye.lookAtTarget = false;
        }
    }
}
