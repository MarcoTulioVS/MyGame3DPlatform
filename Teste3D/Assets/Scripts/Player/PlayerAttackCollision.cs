using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollision : MonoBehaviour
{
    public PlayerAttack playerAttack;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7) // camada de objetos destruitiveis
        {
            if (playerAttack.isAttacking)
            {
                Destroy(other.gameObject);
                StartCoroutine("ResetAttack");
            }
            
        }
        
    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(0.1f);
        playerAttack.isAttacking = false;
    }
}
