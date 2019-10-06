using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "dialogue config")]
public class DiagloueConfig : ScriptableObject
{
    [SerializeField] public float inter_spoken_wait_time = .1f;
    [SerializeField] public float time_between_spoken_and_choices = .2f;
    [SerializeField] public float inter_choice_wait_time = .1f;
    [SerializeField] public float inter_char_time = .05f;
}

public class DialogueWalker : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text spokenPrefab;

    [SerializeField] private Button choicePrefab;

    [SerializeField] private CurrentText startingText;
    
    [SerializeField] private VerticalLayoutGroup textHolder;

    [SerializeField] private DiagloueConfig config;

    private void Start()
    {

        Begin();
    }

    public void Begin()
    {
        StartCoroutine(blitText(startingText));
    }
    
    IEnumerator blitText(CurrentText currentText)
    {
        foreach (Transform t in textHolder.transform)
        {
            Destroy(t.gameObject);
        }
        foreach (var spoken in currentText.spoken)
        {
            yield return StartCoroutine(TypewriterText(
            Instantiate(spokenPrefab.gameObject, Vector3.zero, Quaternion.identity, textHolder.transform)
            
            .GetComponent<TMPro.TMP_Text>(),spoken.text));
            LayoutRebuilder.ForceRebuildLayoutImmediate(textHolder.GetComponent<RectTransform>());
            
            yield return new WaitForSeconds(config.inter_spoken_wait_time);
        }
        yield return  new WaitForSeconds(config.time_between_spoken_and_choices);

        foreach (var choice in currentText.choices)
        {
            GameObject choice_object = Instantiate(choicePrefab.gameObject, textHolder.transform);
            choice_object.GetComponent<Button>().onClick.AddListener(() => StartCoroutine(blitText(choice.dest)));
            yield return StartCoroutine(TypewriterText(
                choice_object.GetComponentInChildren<TMPro.TMP_Text>(), choice.choice
            ));
            
            LayoutRebuilder.ForceRebuildLayoutImmediate(textHolder.GetComponent<RectTransform>());
            yield return new WaitForSeconds(config.inter_choice_wait_time);
        }
        
        
        yield return null;
    }


    IEnumerator TypewriterText(TMPro.TMP_Text text, string line)
    {
        text.text = "";
        text.maxVisibleCharacters = 0;
        string[] words = line.Split(' ');
        for(int i = 0;i < words.Length;i++)
        {
            text.text += words[i];
            text.text += " ";
            for (int j = 0; j < words[i].Length; j++)
            {
                text.maxVisibleCharacters++;
                yield return new WaitForSeconds(config.inter_char_time);
            }

            text.maxVisibleCharacters++;

            yield return null; //unnecessary but I hate loops
        }

    }
}
