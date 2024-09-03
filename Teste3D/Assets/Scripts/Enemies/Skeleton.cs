using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Skeleton : MonoBehaviour,IEnemy
{
    public Enemy enemy;
    private Animator animator;
    private NavMeshAgent agent;

    public Transform target;

    private float detectionRange = 3f;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void Attack()
    {

    }

    public void Move()
    {
        
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            
            
            if (distance<=detectionRange)
            {
                agent.isStopped = false;
                animator.SetBool("walk", true);
                agent.SetDestination(target.position);
            }
            else
            {
                agent.isStopped = true;
                animator.SetBool("walk", false);

            }

        }
    }

    private void Update()
    {
        Move();
    }
}
