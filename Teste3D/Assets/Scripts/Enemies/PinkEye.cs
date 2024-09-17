using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkEye : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    public Animator Animator { get { return this.Animator; } private set { } }

    public Transform target;

    [SerializeField]
    private float speedRotation;

    public bool lookAtTarget;

    public void Attack(bool value)
    {
        animator.SetBool("attack",value);
    }

    public void LookAtTarget()
    {
        Vector3 direction = target.position - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speedRotation * Time.deltaTime);
    }

    private void Update()
    {
        if (lookAtTarget)
        {
            LookAtTarget();
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }
}
