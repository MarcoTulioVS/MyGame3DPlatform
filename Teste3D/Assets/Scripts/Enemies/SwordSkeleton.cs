using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSkeleton : MonoBehaviour
{
    [SerializeField]
    private float damage;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            collision.gameObject.GetComponent<PlayerHealth>().Damage(damage);
        }
    }
}
