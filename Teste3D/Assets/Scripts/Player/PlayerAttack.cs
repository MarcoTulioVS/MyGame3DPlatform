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
    private bool secondAttack;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();

        if (playerInput == null)
        {
            return;
        }
        attackAction = playerInput.actions["Attack"];
        playerController.controls.Player.Attack.performed += ctx => Attack("attack",true);
        playerController.controls.Player.SecondAttack.performed += ctx => Attack("secondAttack",secondAttack);
    }

    private void Start()
    {
        //playerController.controls.Player.Attack.performed += ctx => PerformAttack();
    }


    private void Update()
    {
        
    }

    public void Attack(string name, bool isActive)
    {
        
        if (Time.time >= lastAttackTime + attackCooldown && isActive)
        {
            isAttacking = true;
            lastAttackTime = Time.time;
            anim.SetTrigger(name);
            
        }
    }

    public bool SecondAttack { get { return this.secondAttack; } set { this.secondAttack = value; } }

}
