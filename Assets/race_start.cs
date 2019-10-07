using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class race_start : MonoBehaviour
{
    [SerializeField] private UnityEvent onStart;

    [SerializeField] private TMPro.TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(run());
    }

    IEnumerator run()
    {
        yield return new WaitForSeconds(.5f);
        text.text = "3";
        yield return new WaitForSeconds(1.2f);
        text.text = "2";
        yield return new WaitForSeconds(.8f);
        text.text = "1";
        yield return  new WaitForSeconds(1.3f);
        text.text = "GO!";
        
        onStart.Invoke();
        yield return new WaitForSeconds(.5f);
        text.text = "GO";
        yield return new WaitForSeconds(.1f);
        text.text = "G";
        yield return  new WaitForSeconds(.1f);
        text.text = "";
        
    }
}
