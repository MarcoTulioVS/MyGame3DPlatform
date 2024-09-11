using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyNormalMovement : MonoBehaviour
{
    public Enemy enemy;

    [SerializeField]
    protected Animator animator;
    [SerializeField]
    private NavMeshAgent agent;

    public Transform target;

    protected float detectionRange = 3f;
    protected float distance;

    [SerializeField]
    protected string attackTrigger;

    [SerializeField]
    protected string boolWalk;

    [SerializeField]
    public float boostAnimationSpeed;

    protected bool isAttacking;
    private void Awake()
    {
        //animator = GetComponent<Animator>();
        //agent = GetComponent<NavMeshAgent>();
    }

    public virtual void Attack()
    {
        if (distance < (detectionRange - 1))
        {
            isAttacking = true;
            animator.speed = 2.2f;
            animator.SetTrigger(attackTrigger);
            animator.SetBool(boolWalk, false);
            StartCoroutine("TimeAttack");

        }
    }

    public virtual void Move()
    {

        if (target != null)
        {
            distance = Vector3.Distance(transform.position, target.position);


            if (distance <= detectionRange && !isAttacking)
            {
                animator.speed = 1;
                agent.isStopped = false;
                animator.SetBool(boolWalk, true);
                agent.SetDestination(target.position);
            }
            else
            {
                animator.speed = boostAnimationSpeed;
                agent.isStopped = true;
                animator.SetBool(boolWalk, false);

            }
        }
    }

    private void Update()
    {
        Move();
        Attack();
    }

    protected IEnumerator TimeAttack()
    {
        
        yield return new WaitForSeconds(1.5f);
        isAttacking = false;
        //StopCoroutine("BoostAttackSpeed");
    }
}
