using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    
    [SerializeField] private Transform target;
    [SerializeField] private float rotationSpeed= 300f;

    [SerializeField] private float minXRotation = -10f;
    [SerializeField] private float maxXRotation = 70f;

    [SerializeField] private float minDistance = 2f;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private float zoomSpeed = 2f;
    private float currentDistance = 9f;

    public Vector3 Forward => new Vector3(transform.forward.x, 0, transform.forward.z).normalized;

    public enum RotationMode {Full, YOnly, Locked}

    [SerializeField] private RotationMode rotationMode = RotationMode.Full;


    private float currentYRotation; 
    private float currentXRotation;

    public void SetRotationMode(RotationMode mode)
    {
        rotationMode = mode;
    }



    void Update()
    {
        transform.position = target.position;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if (rotationMode == RotationMode.Full )
            currentYRotation += mouseX * rotationSpeed * Time.deltaTime;

        if (rotationMode == RotationMode.Full || rotationMode == RotationMode.YOnly)
        {
            currentXRotation -= mouseY * rotationSpeed * Time.deltaTime;
            currentXRotation = Mathf.Clamp(currentXRotation, minXRotation, maxXRotation);
        }

        transform.rotation = Quaternion.Euler(currentXRotation, currentYRotation, 0f);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        currentDistance -= scroll * zoomSpeed;
        currentDistance = Mathf.Clamp(currentDistance, minDistance, maxDistance);
        Camera.main.transform.localPosition = new Vector3(0, Camera.main.transform.localPosition.y, -currentDistance);

    }


}
