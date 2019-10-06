using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SerializeEvent : MonoBehaviour
{

    [SerializeField] private UnityEvent[] es;

    public void Call(int i)
    {
        es[i].Invoke();
    }
    
}
