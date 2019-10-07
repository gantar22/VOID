using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

public class delay_event : MonoBehaviour
{
    [SerializeField] private float delay;

    [SerializeField] private UnityEvent e;
    
    public void Trigger()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(delay);
        e.Invoke();
    }
}
