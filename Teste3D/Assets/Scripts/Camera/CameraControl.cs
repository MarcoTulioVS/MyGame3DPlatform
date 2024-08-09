using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    public float speed = 10.0f;                // Velocidade de movimento da câmera
    public float mouseSensitivity = 100.0f;   // Sensibilidade do mouse para rotação
    public float verticalRotationLimit = 80.0f; // Limite de rotação vertical

    private float pitch = 0.0f; // Rotação vertical
    private float yaw = 0.0f;   // Rotação horizontal
    private PlayerInput playerInput; // Referência ao componente PlayerInput
    private InputAction moveAction; // Ação de movimento
    private InputAction lookAction; // Ação de olhar (mouse)

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        if (playerInput == null)
        {
            Debug.LogError("PlayerInput component is missing from the camera.");
            return;
        }

        moveAction = playerInput.actions["Move"];
        lookAction = playerInput.actions["Look"];
    }

    private void Update()
    {
        // Movimento da câmera
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        transform.position += move * speed * Time.deltaTime;

        // Rotação da câmera
        Vector2 lookInput = lookAction.ReadValue<Vector2>();
        float mouseX = lookInput.x;
        float mouseY = lookInput.y;

        yaw += mouseX * mouseSensitivity * Time.deltaTime;
        pitch -= mouseY * mouseSensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -verticalRotationLimit, verticalRotationLimit);

        transform.localRotation = Quaternion.Euler(pitch, yaw, 0.0f);
    }
}
