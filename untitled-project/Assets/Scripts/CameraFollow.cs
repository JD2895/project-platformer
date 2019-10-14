using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform toFollow;
    public float xOffset;
    public float yOffset;

    // Update is called once per frame
    void Update()
    {
        Vector3 newCameraPosition = toFollow.position;
        newCameraPosition = newCameraPosition - (Vector3.forward * xOffset);
        newCameraPosition = newCameraPosition + (Vector3.up * yOffset);
        transform.position = newCameraPosition;
        transform.LookAt(toFollow);
    }
}
