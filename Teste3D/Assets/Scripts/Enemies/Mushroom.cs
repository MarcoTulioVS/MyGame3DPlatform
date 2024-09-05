using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public float bounceForce;
    public float smoothTime = 0.1f;

    private void OnTriggerEnter(Collider collision)
    {
        CharacterController characterController = collision.gameObject.GetComponent<CharacterController>();
        
        if (characterController != null)
        {
            if (characterController.velocity.y < 0)
            {
                Vector3 targetbounce = new Vector3(0, bounceForce, 0);
                characterController.Move(targetbounce * Time.deltaTime);
                
            }
        }
        
    }
    
}
