using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderHit : EnemyWeapon
{
    public Enemy enemy;
    public override void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().Damage(enemy.force);
            
        }
    }
}
