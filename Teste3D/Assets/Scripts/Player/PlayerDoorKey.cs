using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoorKey : MonoBehaviour
{
    [SerializeField]
    private List<int>doorKeys = new List<int>();

    public void AddDoorKey(int value)
    {
        doorKeys.Add(value);
    }

    public bool GetDoorKey(int numberKey)
    {
        bool found = false;

        for(int i = 0; i <doorKeys.Count; i++)
        {
            if (doorKeys.Contains(numberKey))
            {
                found = true;
            }
        }

        return found;
    }
}
