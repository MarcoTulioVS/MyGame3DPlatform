using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectable : MonoBehaviour
{
    public virtual void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag=="Player")
        {
            Debug.Log("Player");
        }
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player");
        }
    }
}
