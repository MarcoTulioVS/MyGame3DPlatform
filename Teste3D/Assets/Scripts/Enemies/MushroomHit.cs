using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomHit : EnemyWeapon
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Mushroom mushroom;
    public override void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mushroom.isAttacking = true;
            StartCoroutine("ExecuteAttack");

        }
    }

    public override void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mushroom.isAttacking = false;
        }
    }
    IEnumerator ExecuteAttack()
    {
        animator.SetBool("active", true);
        yield return new WaitForSeconds(1);
        animator.SetTrigger("attack");
        
    }
}
