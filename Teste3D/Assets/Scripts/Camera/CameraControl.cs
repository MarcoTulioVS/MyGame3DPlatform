using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    public float speed = 10.0f;                // Velocidade de movimento da c�mera
    public float mouseSensitivity = 100.0f;   // Sensibilidade do mouse para rota��o
    public float verticalRotationLimit = 80.0f; // Limite de rota��o vertical

    private float pitch = 0.0f; // Rota��o vertical
    private float yaw = 0.0f;   // Rota��o horizontal
    private PlayerInput playerInput; // Refer�ncia ao componente PlayerInput
    private InputAction moveAction; // A��o de movimento
    private InputAction lookAction; // A��o de olhar (mouse)

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
        // Movimento da c�mera
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        transform.position += move * speed * Time.deltaTime;

        // Rota��o da c�mera
        Vector2 lookInput = lookAction.ReadValue<Vector2>();
        float mouseX = lookInput.x;
        float mouseY = lookInput.y;

        yaw += mouseX * mouseSensitivity * Time.deltaTime;
        pitch -= mouseY * mouseSensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -verticalRotationLimit, verticalRotationLimit);

        transform.localRotation = Quaternion.Euler(pitch, yaw, 0.0f);
    }
}
