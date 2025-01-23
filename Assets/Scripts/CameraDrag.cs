using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("Multiplies how quickly the camera moves while dragging.")]
    public float dragSpeed = 0.2f;

    [Tooltip("How quickly the camera slows down after you release the mouse.")]
    public float friction = 0.9f;

    // Current velocity of the camera (in screen space, converted during Update)
    private Vector3 _currentVelocity;

    // Called by DragTrigger to update the camera's velocity
    public void AddDragVelocity(Vector3 mouseDelta)
    {
        // Multiply the delta by the drag speed to set the new velocity
        // (You could add if you want to accumulate velocity instead)
        _currentVelocity = mouseDelta * dragSpeed;
    }

    void Update()
    {
        // Convert currentVelocity (which is in screen-space units) to world movement.
        // For a simple orthographic top-down camera, you can translate directly.
        // For a perspective camera, you might need a different approach (e.g. raycasting or a transform.right/up projection).

        // Here we assume an orthographic or top-down perspective and move along X/Y in world space:
        transform.Translate(_currentVelocity * Time.deltaTime, Space.World);

        // Apply friction to slow down the camera over time
        _currentVelocity *= friction;
    }
}
