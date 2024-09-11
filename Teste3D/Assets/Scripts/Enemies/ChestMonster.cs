using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMonster : EnemyNormalMovement
{
    public override void Attack()
    {
        if (distance < (detectionRange - 1))
        {
            isAttacking = true;
            animator.SetTrigger(attackTrigger);
            animator.SetBool(boolWalk, false);
            StartCoroutine("TimeAttack");

        }
    }
}
