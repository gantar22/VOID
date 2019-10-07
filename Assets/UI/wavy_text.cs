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
        StartCoroutine(wave());

    }

    IEnumerator wave()
    {
        float time = Time.time;
        while (true)
        {
            time += Time.deltaTime * Random.value * (Mathf.Pow(transform.position.x * transform.position.y,2) % .5f + .5f);
            text.outlineWidth = Mathf.PingPong(time * .2f,1f);
            yield return null;
        }
    }
}
