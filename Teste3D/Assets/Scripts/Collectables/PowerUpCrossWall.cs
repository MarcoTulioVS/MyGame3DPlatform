using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCrossWall : ItemCollectable
{
    public float timePowerUp;
    public override void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(ActiveCrossObject(col));
        }
    }

    IEnumerator ActiveCrossObject(Collider col)
    {
        col.GetComponent<PlayerController>().crossObject = true;
        yield return new WaitForSeconds(timePowerUp);
        col.GetComponent<PlayerController>().crossObject = false;
    }
}
