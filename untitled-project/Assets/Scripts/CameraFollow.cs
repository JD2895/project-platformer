using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform toFollow;
    public float xOffset;
    public float yOffset;

    private Vector3 currentForward;

    private void Start()
    {
        currentForward = Vector3.ProjectOnPlane(toFollow.forward, Vector3.up);
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 newCameraPosition = toFollow.position;
        newCameraPosition = newCameraPosition - (currentForward * xOffset);
        newCameraPosition = newCameraPosition + (Vector3.up * yOffset);
        transform.position = newCameraPosition;
        transform.LookAt(toFollow);

        if (Input.GetKeyDown(KeyCode.C))
        {
            UpdateCurrentForward();
        }
    }

    private void UpdateCurrentForward()
    {
        currentForward = Vector3.ProjectOnPlane(toFollow.forward, Vector3.up);
    }
}
