using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Transform cameraTransform;

    private Rigidbody _rb;
    private float vInput;
    private float hInput;

    void Start()
    {
        _rb = this.GetComponent<Rigidbody>();    
    }

    void FixedUpdate()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
        Vector3 vdisplacement = Vector3.forward * vInput;
        Vector3 hdisplacement = Vector3.right * hInput;
        Vector3 inputDirection = Vector3.Normalize(vdisplacement + hdisplacement);
        Vector3 rawMoveToDelta = inputDirection * moveSpeed * Time.fixedDeltaTime;  // this 'delta' position is in worldspace, need to rotate it to localspace of the player

        // Align with the forward direction of the camera
        Vector3 projectedCameraForward = Vector3.ProjectOnPlane(cameraTransform.forward, Vector3.up);   // Project camera forward onto the xz plane
        Quaternion alignWithCamera = Quaternion.LookRotation(projectedCameraForward, Vector3.up);       // Rotation from Vector3.forward to projectedCameraForward
        Vector3 actualMoveToPosition = this.transform.position + (alignWithCamera * rawMoveToDelta);    // Rotate the 'raw delta' to align with the camera, then add that to player position
        _rb.MovePosition(actualMoveToPosition);
    }
}
