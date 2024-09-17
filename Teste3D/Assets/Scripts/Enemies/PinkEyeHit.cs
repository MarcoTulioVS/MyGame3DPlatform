using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkEyeHit : EnemyWeapon
{
    public Enemy enemy;
    public override void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().Damage(enemy.force);
        }
    }
}
