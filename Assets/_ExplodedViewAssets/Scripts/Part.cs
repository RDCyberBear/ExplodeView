using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(SmoothTransition))]

public class Part : MonoBehaviour
{
    [SerializeField] Transform collapsedPosition;
    [SerializeField] Transform explodedPosition;
    public Bounds bounds { get; private set; }
    
    public MeshFilter meshFilter { get; private set; }
    private MeshRenderer meshRenderer;

    private Vector3 meshPivotOffset;

    private void Awake()
    {
        meshFilter = gameObject.GetComponent<MeshFilter>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshPivotOffset = meshRenderer.bounds.center - transform.position;
        RecalcBounds(transform.position);
    }

    void RecalcBounds(Vector3 position)
    {
        position += meshPivotOffset;
        bounds = new Bounds(position,
                            //meshFilter.mesh.bounds.size);
                            Vector3.Scale(meshFilter.mesh.bounds.size, transform.localScale));
    }

    public void Explode()
    {
        if(explodedPosition != null)
        {
            RecalcBounds(explodedPosition.position);
            GetComponent<SmoothTransition>().TransitTo(explodedPosition);
        }
    }

    public void Collapse()
    {
        if (collapsedPosition != null)
        {
            RecalcBounds(collapsedPosition.position);
            GetComponent<SmoothTransition>().TransitTo(collapsedPosition);
        }
    }

    public void ShowPart(bool show)
    {
        meshRenderer.enabled = show;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(bounds.center, bounds.size);
    }
}
