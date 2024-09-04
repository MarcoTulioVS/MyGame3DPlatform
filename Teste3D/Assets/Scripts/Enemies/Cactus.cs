using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : EnemyNormalMovement
{
    private bool blockRandom;
    public override void Attack()
    {
        if (distance < (detectionRange - 1))
        {
            isAttacking = true;
            StartCoroutine("ApplyRandomNumber");
            animator.SetTrigger(attackTrigger);
            animator.SetBool(boolWalk, false);
            StartCoroutine("TimeAttack");

        }
    }

    private int GetRandomNumber()
    {
        return Random.Range(1, 3);
    }

    IEnumerator ApplyRandomNumber()
    {
        
        if (!blockRandom)
        {
            blockRandom = true;
            int random = GetRandomNumber();

            if (random == 1)
            {

                attackTrigger = "attack";
            }
            else if(random == 2)
            {

                attackTrigger = "secondAttack";
            }

            yield return new WaitForSeconds(3);
            blockRandom = false;
        }
        
    }
}
