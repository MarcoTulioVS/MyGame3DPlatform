//using UnityEngine;
//using UnityEngine.InputSystem;
//namespace StarterAssets
//{

//    public class PlayerController : MonoBehaviour
//    {
//        public CharacterController characterController;
//        public float speed = 5f;
//        public float gravity = -9.8f;
//        public float jumpHeight = 2f;

//        private Vector2 moveInput;
//        private float ySpeed = 0f;
//        private bool isGrounded;

//        private StarterAssetsInputs _playerInput;

//        private void Awake()
//        {
//            _playerInput = new StarterAssetsInputs();
//            _playerInput..performed += ctx => Jump();
//            _playerInput.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
//            _playerInput.Player.Move.canceled += ctx => moveInput = Vector2.zero;
//        }

//        private void OnEnable()
//        {
//            controls.Enable();
//        }

//        private void OnDisable()
//        {
//            controls.Disable();
//        }

//        private void Update()
//        {
//            // Verifica se o personagem está no chão
//            isGrounded = characterController.isGrounded;

//            // Movimento horizontal
//            Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
//            moveDirection = transform.TransformDirection(moveDirection) * speed;

//            // Aplicar gravidade e pulo
//            if (isGrounded)
//            {
//                if (ySpeed < 0)
//                    ySpeed = -2f; // Pequeno valor para manter o personagem no chão
//            }
//            else
//            {
//                ySpeed += gravity * Time.deltaTime;
//            }

//            moveDirection.y = ySpeed;

//            // Mover o personagem
//            characterController.Move(moveDirection * Time.deltaTime);
//        }

//        private void Jump()
//        {
//            if (isGrounded)
//            {
//                ySpeed = Mathf.Sqrt(jumpHeight * -2f * gravity);
//            }
//        }
//    }
//}
