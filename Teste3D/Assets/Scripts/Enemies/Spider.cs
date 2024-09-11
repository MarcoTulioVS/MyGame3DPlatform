using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public Transform player;

    private bool isJumping;
    private void JumpAttack()
    {
        if (!isJumping)
        {
            animator.SetTrigger("jump");
            StartCoroutine("CooldownAttack");
        }
        
    }

    private void Update()
    {
        CalculateDistance();
    }

    private void CalculateDistance()
    {
        float distance = Vector3.Distance(transform.position,player.transform.position);

        if(distance <= 2)
        {
            JumpAttack();       
        }
    }

    IEnumerator CooldownAttack()
    {
        isJumping = true;
        yield return new WaitForSeconds(2);
        isJumping = false;
    }
}
