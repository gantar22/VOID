using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_bool : MonoBehaviour
{
    [SerializeField] private Animator am;
    [SerializeField] private UnitEvent trigger;
    [SerializeField] private string bool_name;

    [SerializeField]
    [Range(0, .25f)] float effect_time;

    // Start is called before the first frame update
    void Start()
    {
        trigger.AddListener(() =>
        {
            StopAllCoroutines();
            StartCoroutine(setunset());
        });
    }

    IEnumerator setunset()
    {
        am.SetBool(bool_name,true);
        yield return new WaitForSeconds(effect_time);
        am.SetBool(bool_name,false);
    }

    
    
}
