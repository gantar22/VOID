using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventHook : MonoBehaviour
{

    [SerializeField] private UnitEvent caller;


    [SerializeField] private UnityEvent listener;
    // Start is called before the first frame update
    void Start()
    {
        caller.AddListener(listener.Invoke);
    }
    
}
