using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Mask))]


public class ListExpand : MonoBehaviour
{
    [SerializeField] float transitionTime = 0.3f;
    [SerializeField] bool colapseOnStart = true;
    private float expandheight;

    private bool inTransition;
    private float transitionElapsedTime;
    private float transitionProgress;

    Vector2 startSize;
    Vector2 targetSize;

    RectTransform rt;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        expandheight = rt.sizeDelta.y;
        if (colapseOnStart)
        {
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, 0f);
        }
    }

    public void ExpandList()
    {
        SizeTransition(expandheight);
    }

    public void ColapseList()
    {
        SizeTransition(0f);
    }

    void SizeTransition(float targeHeight)
    {
        startSize = new Vector2(rt.sizeDelta.x, rt.sizeDelta.y);
        targetSize = new Vector2(rt.sizeDelta.x, targeHeight);
        transitionElapsedTime = 0f;
        inTransition = true;
    }


     void Update()
    {
        if (inTransition)
        {
            transitionElapsedTime += Time.deltaTime;
            transitionProgress = transitionElapsedTime / transitionTime;
            
            if(transitionProgress >= 1f)
            {
                rt.sizeDelta = targetSize;
                inTransition = false;
            }
            else
            {
                rt.sizeDelta = Vector2.Lerp(startSize, targetSize, transitionProgress);
            }
        }
    }
}
