using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class PartButton : MonoBehaviour
{
    [SerializeField] Part part;
    [SerializeField] ViewportRotate viewportControl;
    [SerializeField] PartsAssembly partsAssembly;


    void OnEanble()
    {
       GetComponent<Button>().onClick.AddListener(FocusOnPart);
    }

    void OnDisable()
    {
       GetComponent<Button>().onClick.RemoveListener(FocusOnPart);
    }

    public void FocusOnPart()
    {
        partsAssembly.FocusOnPart(part);
    }

}
