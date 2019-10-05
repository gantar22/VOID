using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum flags { };


[System.Serializable]
public struct Line {

    [TextArea]
    public string text;

}

[System.Serializable]
public struct Choice {

    public string choice;
    public CurrentText dest;
    public flags[] required;
    public flags[] set_true;
    public flags[] set_false;
}

[CreateAssetMenu(menuName = "Text")]
public class CurrentText : ScriptableObject
{

    public Line[] spoken;
    public Choice[] choices;

}
