using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollision : MonoBehaviour
{
    public PlayerAttack playerAttack;
    public ParticleSystem particle;

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7) // camada de objetos destruitiveis
        {
            if (playerAttack.isAttacking)
            {
                particle = other.gameObject.GetComponentInChildren<ParticleObject>().GetParticleSystem();
                other.gameObject.GetComponentInChildren<ParticleSystem>().transform.SetParent(null);
                Destroy(other.gameObject);
                particle.Play();
                Destroy(particle.gameObject,1);
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
