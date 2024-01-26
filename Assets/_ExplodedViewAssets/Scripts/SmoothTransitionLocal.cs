using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothTransitionLocal : MonoBehaviour
{
    [SerializeField] float transitionTime = 0f;

    private bool inTransition;
    private float transitionElapsedTime;
    private float transitionProgress;

    private Vector3 startPosition;
    private Vector3 endPosition;

    public void TransitTo(Transform endPoint)
    {
        TransitFromTo(transform, endPoint);
    }

    public void TransitFromTo(Transform startPoint, Transform endPoint)
    {
        startPosition = startPoint.localPosition;
        endPosition = endPoint.localPosition;
        transitionElapsedTime = 0f;
        inTransition = true;
    }

    public void TransitTo(Vector3 endPoint)
    {
        TransitFromTo(transform.localPosition, endPoint);
    }

    public void TransitFromTo(Vector3 startPoint, Vector3 endPoint)
    {
        startPosition = startPoint;
        endPosition = endPoint;
        transitionElapsedTime = 0f;
        inTransition = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (inTransition)
        {
            transitionElapsedTime += Time.deltaTime;
            transitionProgress = transitionElapsedTime / transitionTime;
            
            if(transitionProgress >= 1f)
            {
                transform.localPosition = endPosition;
                inTransition = false;
            }
            else
            {
                transform.localPosition = Vector3.Lerp(startPosition, endPosition, transitionProgress);
            }
        }
    }
}
