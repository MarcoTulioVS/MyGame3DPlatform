using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public float bounceForce;
    public float smoothTime = 0.1f;
    public bool isAttacking;
    public Enemy enemy;

    private Vector3 bounceVelocity = Vector3.zero;

    public float maxBounceVelocity = 20f;

    private bool activeJump;
    private void OnTriggerEnter(Collider collision)
    {
        CharacterController characterController = collision.gameObject.GetComponent<CharacterController>();

        if (characterController != null && !isAttacking)
        {
            if (characterController.velocity.y < 0)
            {
                
                if (!activeJump)
                {
                    StartCoroutine(CoolDownJump());
                    Vector3 targetBounce = new Vector3(0, bounceForce, 0);
                    characterController.Move(targetBounce * Time.deltaTime);
                }

            }
        }

        if (collision.gameObject.tag == "Player" && isAttacking)
        {
            collision.gameObject.GetComponent<PlayerHealth>().Damage(enemy.force);

        }

    }

    IEnumerator CoolDownJump()
    {
        activeJump = true;
        yield return new WaitForSeconds(1f);
        activeJump = false;
        
    }

}
