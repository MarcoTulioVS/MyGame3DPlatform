using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollectable : ItemCollectable
{
    [SerializeField]
    private int numberKey;

    public override void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerDoorKey>().AddDoorKey(numberKey);
            Destroy(gameObject);
        }
    }

}
