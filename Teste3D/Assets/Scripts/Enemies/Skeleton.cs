using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour,IEnemy
{
    public Enemy enemy;
    private Animator animator;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Attack()
    {

    }

    public void Move()
    {

    }
}
