using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 2f;

    private Vector2 moveInput;
    private Vector2 lookInput;
    private float ySpeed = 0f;
    private bool isGrounded;

    
    public PlayerControls controls;
    private Animator animator;

    public float mouseSensitivity;
    public float rotationSpeed = 700;
    private float xRotation;

    public Transform playerCamera;


    public PlayerAttack playerAttack;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        controls = new PlayerControls();
        controls.Player.Jump.performed += ctx => Jump();
        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
        controls.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        controls.Player.Look.canceled += ctx => lookInput = Vector2.zero;
        controls.Player.Block.performed += ctx => Block(true);
        controls.Player.Block.canceled += ctx => Block(false);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        // Verifica se o personagem está no chão
        isGrounded = characterController.isGrounded;

        // Movimento horizontal
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        moveDirection = transform.TransformDirection(moveDirection) * speed;

        // Aplicar gravidade e pulo
        if (isGrounded)
        {
            if (ySpeed < 0)
                ySpeed = -2f; // Pequeno valor para manter o personagem no chão
        }
        else
        {
            ySpeed += gravity * Time.deltaTime;
        }

        moveDirection.y = ySpeed;

        // Mover o personagem
        characterController.Move(moveDirection * Time.deltaTime);

        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, 5, 15);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * mouseX);
        UpdateAnimator(moveDirection);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            ySpeed = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void UpdateAnimator(Vector3 moveDirection)
    {
        float speed = new Vector2(moveDirection.x, moveDirection.z).magnitude;
        animator.SetFloat("Speed", speed);
        animator.SetBool("IsJumping", !isGrounded);
    }

    public void Block(bool value)
    {
        animator.SetBool("block", value);
        //Incrementar mais codigos para fazer com que o personagem não tome dano
    }

}
