using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFallDown : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 initialPos;

    [SerializeField]
    private Transform trPlatform;

    [SerializeField]
    private float timeFall;

    [SerializeField]
    private float timeGoBack;
    private void Start()
    {
        initialPos = trPlatform.position;
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine("StartCountingTime");
        }
    }

    IEnumerator StartCountingTime()
    {
        yield return new WaitForSeconds(timeFall);
        rb.useGravity = true;
        yield return new WaitForSeconds(timeGoBack);
        rb.velocity = Vector3.zero;
        rb.useGravity = false;
        transform.position = initialPos;
        StopCoroutine("StartCountingTime");
    }

}
