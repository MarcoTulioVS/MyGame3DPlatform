using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BrokenVector.LowPolyFencePack;
public class DoorCollision : MonoBehaviour
{
    public int numberKey;

    public DoorController controller;
    public GameObject block;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bool keyFounded = collision.gameObject.GetComponent<PlayerDoorKey>().GetDoorKey(numberKey);
            
            if (keyFounded)
            {
                block.SetActive(false);
                controller.OpenDoor();
            }
            else
            {
                controller.CloseDoor();
            }
        }
    }

}
