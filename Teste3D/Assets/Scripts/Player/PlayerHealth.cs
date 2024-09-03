using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float health;
    public float CurrentHealth { get; set; }

    private void Start()
    {
        CurrentHealth = health;
    }
    public void Damage(float value)
    {
        CurrentHealth -= value;
    }
}
