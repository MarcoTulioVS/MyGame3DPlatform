using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBlockCollision : MonoBehaviour
{
    public float timeBlockTrigger;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            if (collision.gameObject.GetComponent<PlayerController>().crossObject)
            {
                StartCoroutine("DisableBlockTrigger");
            }
        }
    }
    IEnumerator DisableBlockTrigger()
    {
        gameObject.GetComponent<Collider>().isTrigger = true;
        yield return new WaitForSeconds(timeBlockTrigger);
        gameObject.GetComponent<Collider>().isTrigger = false;
    }
}
