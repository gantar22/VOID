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
}

public class DialogueWalker : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text spokenPrefab;

    [SerializeField] private Button choicePrefab;

    [SerializeField] private CurrentText startingText;
    
    [SerializeField] private VerticalLayoutGroup textHolder;

    [SerializeField] private DiagloueConfig config;

    IEnumerator blitText(CurrentText currentText)
    {
        foreach (Transform t in textHolder.transform)
        {
            Destroy(t.gameObject);
        }
        foreach (var spoken in currentText.spoken)
        {
            Instantiate(spokenPrefab.gameObject, Vector3.zero, Quaternion.identity, textHolder.transform)
            
            .GetComponent<TMPro.TMP_Text>().text = spoken.text;
            
            yield return new WaitForSeconds(config.inter_spoken_wait_time);
        }
        yield return  new WaitForSeconds(config.time_between_spoken_and_choices);

        foreach (var choice in currentText.choices)
        {
            GameObject choice_object = Instantiate(choicePrefab.gameObject, textHolder.transform);
            choice_object.GetComponent<Button>().onClick.AddListener(() => StartCoroutine(blitText(choice.dest)));
            yield return new WaitForSeconds(config.inter_choice_wait_time);
        }
        
        
        yield return null;
    }
}
