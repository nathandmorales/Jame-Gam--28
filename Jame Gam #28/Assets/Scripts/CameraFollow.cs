using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Reference to the player's transform
    public float smoothSpeed = 0.125f;  // Smoothing factor for camera movement
    public Vector2 offset;  // Offset from the player

    void LateUpdate()
    {
        // Calculate the desired position of the camera
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
        // Use SmoothDamp to gradually move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
