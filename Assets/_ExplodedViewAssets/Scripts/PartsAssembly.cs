using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]

public class PartsAssembly : MonoBehaviour
{
    [SerializeField] ViewportRotate viewportControl;
    [SerializeField] List<Part> parts = new List<Part>();

    public Bounds bounds { get; private set; }

    private void Start()
    {
        RecalcAssemblyBounds();
    }

    public void FocusOnAssembly()
    {
        viewportControl.FocusOn(bounds);
        ShowAllParts(true);
    }

    public void FocusOnPart(Part part)
    {
        viewportControl.FocusOn(part.bounds);
        ShowPart(part);
    }

    void RecalcAssemblyBounds()
    {
        Bounds newBounds = new Bounds();
        if(parts.Count > 0)
        {
            newBounds.center = parts[0].bounds.center;
            newBounds.size = parts[0].bounds.size;
        }
        foreach(var part in parts)
        {
            if(part == parts[0])
                continue;
            newBounds.Encapsulate(part.bounds);
        }
        bounds = newBounds;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(bounds.center, bounds.size);
    }

    public void ExplodeAssembly()
    {
        ShowAllParts(true);
        foreach(var part in parts)
        {
            part.Explode();
        }
        RecalcAssemblyBounds();
        FocusOnAssembly();
    }

    public void ColapseAssembly()
    {
        ShowAllParts(true);
        foreach (var part in parts)
        {
            part.Collapse();
        }
        RecalcAssemblyBounds();
        FocusOnAssembly();
    }


    public void ShowPart(Part part)
    {
        ShowAllParts(false);
        part.ShowPart(true);
    }


    void ShowAllParts(bool show)
    {
        foreach(var part in parts)
        {
            part.ShowPart(show);
        }
    }

}
