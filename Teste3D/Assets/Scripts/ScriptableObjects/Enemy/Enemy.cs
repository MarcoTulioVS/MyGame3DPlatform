using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/New Enemy",fileName = "New Enemy")]
public class Enemy:ScriptableObject
{
    
    public float force;
    public float speed;
    public float life;

}
