using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplete : MonoBehaviour
{
    [SerializeField] private AudioSource[] _audioSources;
    
    public void go()
    {
        foreach (AudioSource source in _audioSources)
        {
            source.volume = Mathf.Lerp(.3f, source.volume, .7f);
        }

        foreach (ParticleSystem system in GetComponentsInChildren<ParticleSystem>())
        {
            ParticleSystem.EmissionModule emissionModule = system.emission;
            emissionModule.rateOverTimeMultiplier *= .7f;// = system.emission.rateOverTimeMultiplier * .5f;
        }
    }
}
