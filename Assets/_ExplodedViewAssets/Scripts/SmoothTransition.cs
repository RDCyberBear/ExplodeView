using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothTransition : MonoBehaviour
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
        startPosition = startPoint.position;
        endPosition = endPoint.position;
        transitionElapsedTime = 0f;
        inTransition = true;
    }

    public void TransitTo(Vector3 endPoint)
    {
        TransitFromTo(transform.position, endPoint);
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
                transform.position = endPosition;
                inTransition = false;
            }
            else
            {
                transform.position = Vector3.Lerp(startPosition, endPosition, transitionProgress);
            }
        }
    }
}
