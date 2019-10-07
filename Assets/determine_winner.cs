using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class determine_winner : MonoBehaviour
{
    private bool player;
    private bool opponent;
    [SerializeField] private UnityEvent win;
    [SerializeField] private UnityEvent lose;
    
    public void player_done()
    {
        if(!opponent)
            StartCoroutine(wait_for_opponent());
        player = true;
    }

    IEnumerator wait_for_opponent()
    {
        yield return new WaitUntil(() => opponent);
        win.Invoke();
    }
    
    public void opponent_done()
    {
        if(!player)
            StartCoroutine(wait_for_player());
        opponent = true;
    }

    IEnumerator wait_for_player()
    {
        yield return new WaitUntil(() => player);
        lose.Invoke();
    }
    
}
