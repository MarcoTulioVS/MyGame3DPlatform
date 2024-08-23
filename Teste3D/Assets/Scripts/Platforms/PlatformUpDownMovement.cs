using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUpDownMovement : MonoBehaviour
{
    public float speed = 5;
    public float timeGoBack = 0.8f;

    [SerializeField]
    private bool GoUp = true;


    private void Start()
    {
        StartCoroutine("TimeGoBack");
    }

    private void FixedUpdate()
    {
        if (GoUp)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
            
        }

    }

    IEnumerator TimeGoBack()
    {

        yield return new WaitForSeconds(timeGoBack);
        GoUp = false;
        yield return new WaitForSeconds(timeGoBack);
        GoUp = true;
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
