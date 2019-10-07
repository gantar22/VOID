using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class player_finish : MonoBehaviour
{
    [SerializeField] private UnityEvent onEnd;

    [SerializeField] private FloatRef normalized_pos;
    // Start is called before the first frame update
    void Start()
    {
        normalized_pos.val = 0;
        StartCoroutine(run());
    }

    IEnumerator run()
    {
        yield return new WaitUntil(() => 1 - normalized_pos.val < -.02f);
        onEnd.Invoke();
    }
}
