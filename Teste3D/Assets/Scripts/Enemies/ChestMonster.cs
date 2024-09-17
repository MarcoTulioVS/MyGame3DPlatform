using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMonster : EnemyNormalMovement
{
    public BoxCollider col;

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

    protected override void Update()
    {
        Move();
        Attack();
        ActivateCollider();
    }

    public void ActivateCollider()
    {
        if (isAttacking)
        {
            col.enabled = true;
        }
        else
        {
            col.enabled = false;
        }
    }
}
