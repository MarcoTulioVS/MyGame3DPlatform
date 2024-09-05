using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public float bounceForce;
    public float smoothTime = 0.1f;
    public bool isAttacking;
    public Enemy enemy;
    private void OnTriggerEnter(Collider collision)
    {
        CharacterController characterController = collision.gameObject.GetComponent<CharacterController>();

        if (characterController != null && !isAttacking)
        {
            if (characterController.velocity.y < 0)
            {
                Vector3 targetbounce = new Vector3(0, bounceForce, 0);
                characterController.Move(targetbounce * Time.deltaTime);

            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && isAttacking)
        {
            collision.gameObject.GetComponent<PlayerHealth>().Damage(enemy.force);
            Debug.Log(collision.gameObject.GetComponent<PlayerHealth>().CurrentHealth);

        }
    }

}
