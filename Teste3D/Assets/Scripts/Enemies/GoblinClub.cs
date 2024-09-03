using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinClub : EnemyWeapon
{
    public Enemy enemy;
    public override void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().Damage(enemy.force);
        }
    }
}
