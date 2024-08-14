using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    
    public float attackCooldown = 0.5f;
    private float lastAttackTime = -Mathf.Infinity;
    private Animator anim;
    private PlayerInput playerInput;
    private InputAction attackAction;

    private PlayerControls playerControls;

    public PlayerController playerController;
    public bool isAttacking;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();

        if (playerInput == null)
        {
            return;
        }
        attackAction = playerInput.actions["Attack"];
        playerController.controls.Player.Attack.performed += ctx => Attack();
        
    }

    private void Start()
    {
        //playerController.controls.Player.Attack.performed += ctx => PerformAttack();
    }


    private void Update()
    {
        
    }

    private void PerformAttack()
    {
        lastAttackTime = Time.time;
        anim.SetTrigger("attack");

    }

    public void Attack()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            isAttacking = true;
            PerformAttack();
        }
    }
}
