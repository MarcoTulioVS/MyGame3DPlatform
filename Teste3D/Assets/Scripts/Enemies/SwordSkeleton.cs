using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSkeleton : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

        }
    }
}
