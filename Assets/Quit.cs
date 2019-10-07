using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    [SerializeField]
    UnitEvent unit;

    // Start is called before the first frame update
    void Start()
    {
        unit.AddListener(() => Application.Quit());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
