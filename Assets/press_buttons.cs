using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct button_images
{
    [SerializeField] public KeyCode button;
    [SerializeField] public Sprite up_image;
    [SerializeField] public Sprite down_image;
    [SerializeField] public SpriteRenderer sr;
}

public class press_buttons : MonoBehaviour
{

    [SerializeField] private UnitEvent run_forward;
    [SerializeField] private button_images left;
    [SerializeField] private button_images right;

   
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(set_buttons(left));
        StartCoroutine(set_buttons(right));
        StartCoroutine(run());
    }


    IEnumerator set_buttons(button_images im)
    {
        while (true)
        {
            while (Input.GetKey(im.button))
            {
                im.sr.sprite = im.down_image;
                yield return null;
            }

            while (!Input.GetKey(im.button))
            {
                im.sr.sprite = im.up_image;
                yield return null;
            }
        }
    }

    IEnumerator run()
    {
        yield return new WaitUntil(() => 
            Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow));
        KeyCode nextKey = Input.GetKeyDown(KeyCode.LeftArrow) ? KeyCode.RightArrow : KeyCode.LeftArrow;
        while (gameObject.activeInHierarchy)
        {
            run_forward.Invoke();
            yield return new WaitUntil(() => Input.GetKeyDown(nextKey));
            nextKey = nextKey == KeyCode.LeftArrow ? KeyCode.RightArrow : KeyCode.LeftArrow;
        }
    }
}
