using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SerializeEvent : MonoBehaviour
{

    [SerializeField] private UnityEvent[] es;

    public void Invoke(int i)
    {
        es[i].Invoke();
    }
    
}
