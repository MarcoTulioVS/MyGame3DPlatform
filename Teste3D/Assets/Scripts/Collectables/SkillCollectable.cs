using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCollectable : ItemCollectable
{
    public PlayerAttack playerAttack;
    public override void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerAttack.SecondAttack = true;
            Destroy(gameObject);
        }
    }
}
