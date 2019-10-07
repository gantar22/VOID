using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_audio : MonoBehaviour
{

    [SerializeField] private AudioClip[] clips;

    public void Play()
    {
        if (Random.value > .7f)
        {
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(clips[Random.Range(0,clips.Length) % clips.Length]);

            
        }
        
    }
}
