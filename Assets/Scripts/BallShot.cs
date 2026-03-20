using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShot : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] private CameraController cameraTransform;
    [SerializeField] private float forceMultiplier = 10f;
    [SerializeField] private float maxAngle = 45f;
    [SerializeField] private float angleSpeed = 45f;
    private float angleDirection = 1f;

    private Rigidbody rb;

    private enum ShotState { Idle, ChoosingDirection, ChoosingAngle, Moving}

    private ShotState state = ShotState.Idle;

    private Vector3 lockedDirection;
    private float lockedForce;
    private float clickTime;

    private float currentAngle;

    private LineRenderer lineRenderer;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();

        if (lineRenderer.enabled)
        {
            if (state == ShotState.ChoosingDirection)
            {
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, transform.position + cameraTransform.Forward * 3f);
            }
            else if (state == ShotState.ChoosingAngle)
            {
                lineRenderer.SetPosition(0, transform.position);
                Vector3 direction = Quaternion.AngleAxis(currentAngle, Vector3.Cross(lockedDirection, Vector3.up)) * lockedDirection;
                lineRenderer.SetPosition(1, transform.position + direction * 3f);
            }
        }
        if (state == ShotState.ChoosingAngle)
        {
            currentAngle += angleDirection * angleSpeed * Time.deltaTime;
            if (currentAngle >= maxAngle || currentAngle <= 0f)
                angleDirection *= -1f;
        }

        if (state == ShotState.Moving && rb.velocity.magnitude < 0.1f)
        {
            state = ShotState.Idle;
        }
    }

    void HandleInput()
    {
        if (state == ShotState.Idle && Input.GetMouseButtonDown(0))
        {
            clickTime = Time.time;
            state = ShotState.ChoosingDirection;
            lineRenderer.enabled = true;
        }
        else if (state == ShotState.ChoosingDirection && Input.GetMouseButtonUp(0))
        {
            lockedForce = (Time.time - clickTime) * forceMultiplier;
            lockedDirection = cameraTransform.Forward;
            Debug.Log("Hold duration: " + (Time.time - clickTime) + " | Force: " + lockedForce);
            cameraTransform.SetRotationMode(CameraController.RotationMode.YOnly);
            state = ShotState.ChoosingAngle;
        }
        else if (state == ShotState.ChoosingAngle && Input.GetMouseButtonDown(0))
        {
            ShootBall();
            state = ShotState.Moving;
            lineRenderer.enabled = false;
            cameraTransform.SetRotationMode(CameraController.RotationMode.Full);
        }
    }

    void ShootBall()
    {
        Vector3 direction = Quaternion.AngleAxis(currentAngle, Vector3.Cross(lockedDirection, Vector3.up)) * lockedDirection;

        rb.AddForce(direction * lockedForce, ForceMode.Impulse);
    }
}
