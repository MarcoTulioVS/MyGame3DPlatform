using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float speed = 5;
    public float timeGoBack = 0.8f;

    [SerializeField]
    private bool GoAhead = true;

    private void Start()
    {
        StartCoroutine("TimeGoBack");
    }

    private void FixedUpdate()
    {
        if (GoAhead)
        {
            
            transform.position+= Vector3.right * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            transform.position -= Vector3.right * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, -90, 0);
            
        }
        
    }

    IEnumerator TimeGoBack()
    {
        
        yield return new WaitForSeconds(timeGoBack);
        GoAhead = false;
        yield return new WaitForSeconds(timeGoBack);
        GoAhead = true;
        StartCoroutine("TimeGoBack");
    }

    private void OnTriggerEnter(Collider hit)
    {
        
        if (hit.gameObject.tag == "Player")
        {
            hit.transform.parent = transform;
            
        }
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            
            hit.transform.parent = null;

        }
    }

    
}
