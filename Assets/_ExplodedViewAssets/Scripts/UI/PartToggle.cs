using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]

public class PartToggle : MonoBehaviour
{
    [SerializeField] Part part;
    [SerializeField] PartsToggleGroup tgGroup;

    [SerializeField] PartsAssembly partsAssembly;

    private Toggle tg;

    void Awake()
    {
        tg = GetComponent<Toggle>();
    }

    public void FocusOnPart()
    {
        if(tg.isOn)
        {
            partsAssembly.FocusOnPart(part);
        }
        else
        {
            tgGroup.UpdatePartFocus();
        }
        
        
    }
}
