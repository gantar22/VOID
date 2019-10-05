using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TMPro.TMP_Text))]
public class wavy_text : MonoBehaviour
{
    TMPro.TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TMP_Text>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
