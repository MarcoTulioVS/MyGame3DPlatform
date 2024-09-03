using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float health;
    public float CurrentHealth { get; set; }

    private bool doDamage;
    private void Start()
    {
        CurrentHealth = health;
        
    }
    public void Damage(float value)
    {
        if (CurrentHealth > 0)
        {
            if (!doDamage)
            {
                doDamage = true;
                CurrentHealth -= value;
                StartCoroutine("CoolDownDamage");
            }
            
        }

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
        }
        
    }

    IEnumerator CoolDownDamage()
    {
        yield return new WaitForSeconds(1);
        doDamage = false;
        StopCoroutine(CoolDownDamage());
        
    }
}
