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
    private void Start()
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
            agent.SetDestination(target.position);
        }
    }

    private void Update()
    {
        Move();
    }
}
