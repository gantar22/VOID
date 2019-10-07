using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class opponent_runner : MonoBehaviour
{
    [SerializeField] private FloatRef normalized_player_pos;

    [SerializeField] private Transform starting_point;

    [SerializeField] private Transform ending_point;
    [SerializeField] private Transform flag;
    [SerializeField] private UnityEvent OnFinish;

    private void Start()
    {
        StartCoroutine(set_pos());
    }

    IEnumerator set_pos()
    {
        float extra_time = 0;
        Vector3 vel = Vector3.zero;
        while (true)
        {
            transform.position = Vector3.SmoothDamp(transform.position, Vector3.LerpUnclamped(starting_point.position, 
                ending_point.position,
                Mathf.Pow(normalized_player_pos.val,2) - extra_time),ref vel,.2f);
            extra_time += Time.deltaTime * .06f;
            yield return null;
            if (Mathf.Abs(transform.position.x - flag.position.x) < .05f)
            {
                OnFinish.Invoke();
                GetComponent<Animator>().SetTrigger("stop");
                yield break;
            }
        }
    }


}
