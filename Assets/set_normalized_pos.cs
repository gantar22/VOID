using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_normalized_pos : MonoBehaviour
{
    [SerializeField] private Transform start_pos;

    [SerializeField] private Transform end_pos;

    [SerializeField] private FloatRef out_pos;
    

    // Update is called once per frame
    void Update()
    {
        out_pos.val = Vector3.Distance(start_pos.position, transform.position) /
                      Vector3.Distance(start_pos.position, end_pos.position);
    }
}
