﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;



public enum Flag { obeyed, playing0, playing1, playing2 , pull_slot_machine, knockedchoc, knockeddrink, knockedtuna, choc, drink, tuna, notnose, nose,
                    return1, return2, return3, return4, return5, win_race};

public enum Speaker : int { the_void, angry_void, player, clerk, narrator}

[System.Serializable]
public struct Line
{
    public Flag[] required;

    public Speaker speaker;

    [TextArea(2,15)]
    public string text;

}

[System.Serializable]
public struct Choice {

    public string choice;
    public CurrentText dest;
    public Flag[] required;
    public Flag[] set_true;
    public Flag[] set_false;
}

[CreateAssetMenu(menuName = "Text")]
public class CurrentText : ScriptableObject
{
    public UnityEvent on_enter;
    public UnityEvent on_exit;
    public Line[] spoken;
    public Choice[] choices;

} 
