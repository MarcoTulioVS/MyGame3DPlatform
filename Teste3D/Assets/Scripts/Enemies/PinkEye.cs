using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkEye : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    
    public void Attack(bool value)
    {
        animator.SetBool("attack",value);
    }

    public Animator Animator { get { return this.Animator; } private set { } }
}
