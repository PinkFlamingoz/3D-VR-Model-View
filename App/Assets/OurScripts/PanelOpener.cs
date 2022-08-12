using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    //public GameObject Panel;
    //public void OpenPanel()
    //{
    //    if(Panel != null)
    //    {
    //        bool isActive = Panel.activeSelf;
    //        Panel.SetActive(!isActive);
    //    }
    //}

    private bool mFaded = false;
    public float Duration = 0.4f;

    public void Fade()
    {
        var canvGroup = GetComponent<CanvasGroup>();

        // Toggle the end value
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, mFaded ? 1 : 0));

        // Toggle the faded state
        mFaded = !mFaded;
    }

    public IEnumerator DoFade(CanvasGroup canvGroup,float start,float end)
    {
        float counter = 0f;

        while(counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / Duration);
            yield return null;
        }
    }


    
}
