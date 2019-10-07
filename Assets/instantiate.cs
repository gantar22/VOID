using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class instantiate : MonoBehaviour
{
    [SerializeField] private GameObject object_to_spawn;

    [SerializeField] private Transform dest;

    [SerializeField] private UnityEvent e;
    private void Start()
    {
        StartCoroutine(go(Instantiate(object_to_spawn,Vector3.right * 5,Quaternion.identity)));
    }

    IEnumerator go(GameObject g)
    {
        Vector3 vel = Vector3.up - Vector3.right;
        
        while (Vector3.Distance(g.transform.position,dest.position) > .25f)
        {
            g.transform.position = Vector3.SmoothDamp(g.transform.position, 
                dest.position + Vector3.up * Mathf.Sin(Time.time * 3)  * 2, ref vel, 2f);
            yield return null;
        }
        Destroy(g);
        e.Invoke();
    }
}
