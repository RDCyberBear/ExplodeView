using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ToggleGroup))]

public class PartsToggleGroup : MonoBehaviour
{
    [SerializeField] PartsAssembly partsAssembly;

    private ToggleGroup tgGroup;
    
    void Start()
    {
        tgGroup = GetComponent<ToggleGroup>();
    }

    public void ResetAllToggles()
    {
        tgGroup.SetAllTogglesOff();
        partsAssembly.FocusOnAssembly();
    }


    public void UpdatePartFocus()
    {
        if (!tgGroup.AnyTogglesOn())
        {
            partsAssembly.FocusOnAssembly();
        }
    }
}
