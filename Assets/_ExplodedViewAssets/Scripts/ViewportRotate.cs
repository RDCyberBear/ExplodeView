using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewportRotate : MonoBehaviour
{
    [SerializeField] SmoothTransition cameraPOI;
    [SerializeField] SmoothTransitionLocal camera;
    
    [SerializeField] float zoomScale = 1f;

    [SerializeField] float HRotateSpeed = 1f;
    [SerializeField] float VRotateSpeed = 1f;
    [SerializeField] float mouseSensitivity = 1f;
    [SerializeField] float clampAngleVertical = 85f;



    private float verticalAngle;
    private float HorizontalAngle;
    private float zoomDisatance;
    private Vector3 currentPOI;

    void Start()
    {
        currentPOI = cameraPOI.transform.position;
    }

    public void FocusOn(Part part)
    {
        FocusOn(part.bounds);
    }

    public void FocusOn(Bounds bounds)
    {
        currentPOI = bounds.center;
        zoomDisatance = bounds.size.magnitude * zoomScale * -1;
        cameraPOI.TransitTo(currentPOI);
        camera.TransitTo(new Vector3(0, 0, zoomDisatance));    
    }

    public void Rotate(float horizAngle, float vertAngle)
    {
        verticalAngle += vertAngle;
        verticalAngle = Mathf.Clamp(verticalAngle, -1 * clampAngleVertical, clampAngleVertical);
        cameraPOI.transform.Rotate(0, horizAngle, 0, Space.World);
        cameraPOI.transform.localEulerAngles = new Vector3(verticalAngle, cameraPOI.transform.localEulerAngles.y, cameraPOI.transform.localEulerAngles.z);
    }

    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Rotate(Input.GetAxis("Horizontal") * -1 * HRotateSpeed, Input.GetAxis("Vertical") * VRotateSpeed);
        }

        if(Input.GetMouseButton(1))
        {
            Rotate(Input.GetAxis("Mouse X") * mouseSensitivity, Input.GetAxis("Mouse Y") * -1f * mouseSensitivity);
        }
    }
}
