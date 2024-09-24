using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    public CharacterController characterController;
    public float speed;
    public float turnSpeed = 1;
    public float gravity = -9.8f;

    private float vSpeed;

    public float jumpSpeed;
    public Animator animator;

    private void Update()
    {
        transform.Rotate(0,Input.GetAxis("Horizontal")*turnSpeed*Time.deltaTime,0);
        var inputAxisVertical = Input.GetAxis("Vertical");
        var speedVector = transform.forward * inputAxisVertical * speed;

        if (characterController.isGrounded)
        {
            vSpeed = 0;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                vSpeed = jumpSpeed;
            }
        }

        vSpeed-=gravity*Time.deltaTime;
        speedVector.y = vSpeed;

        characterController.Move(speedVector * Time.deltaTime);
        animator.SetBool("Run",inputAxisVertical!=0);
        
        
    }
}
