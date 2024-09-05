using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField]
    private float damage;
    public virtual void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.GetComponent<PlayerHealth>().Damage(damage);
        }
    }

    public virtual void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Code
        }
    }

    public virtual void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Code
        }
    }
}
