using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyNormalMovement : MonoBehaviour
{
    public Enemy enemy;
    private Animator animator;
    private NavMeshAgent agent;

    public Transform target;

    private float detectionRange = 3f;
    private float distance;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void Attack()
    {
        if (distance < (detectionRange - 1))
        {
            animator.speed = 2.2f;
            animator.SetTrigger("attack");
            animator.SetBool("walk", false);

        }
    }

    public void Move()
    {

        if (target != null)
        {
            distance = Vector3.Distance(transform.position, target.position);


            if (distance <= detectionRange)
            {
                animator.speed = 1;
                agent.isStopped = false;
                animator.SetBool("walk", true);
                agent.SetDestination(target.position);
            }
            else
            {
                animator.speed = 2.2f;
                agent.isStopped = true;
                animator.SetBool("walk", false);

            }
        }
    }

    private void Update()
    {
        Move();
        Attack();
    }

    IEnumerator BoostAttackSpeed()
    {
        animator.speed = 2.2f;
        yield return new WaitForSeconds(1.5f);
        animator.speed = 1f;
        StopCoroutine("BoostAttackSpeed");
    }
}
