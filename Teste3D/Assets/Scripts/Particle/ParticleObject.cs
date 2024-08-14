using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleObject : MonoBehaviour
{
    private ParticleSystem particle;
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        
    }

    public ParticleSystem GetParticleSystem()
    {
        return particle;
    }
}
