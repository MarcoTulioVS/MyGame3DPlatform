using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHigherJump : ItemCollectable
{
    [SerializeField]
    private float increaseHight = 2f;
    [SerializeField]
    private float timePowerUp = 5f;
    public override void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(BoostJumpHight(col));
        }
        
    }

    IEnumerator BoostJumpHight(Collider col)
    {
        col.gameObject.GetComponent<PlayerController>().jumpHeight += increaseHight;
        yield return new WaitForSeconds(timePowerUp);
        col.gameObject.GetComponent<PlayerController>().jumpHeight -= increaseHight;
    }
}
