using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDragTrigger : MonoBehaviour
{
    [SerializeField] private CameraDrag cameraDrag;

    private Vector3 _lastMousePosition;
    private bool _isDragging = false;

    void Update()
    {
        // Check for right mouse button down
        if (Input.GetMouseButtonDown(1))
        {
            _isDragging = true;
            _lastMousePosition = Input.mousePosition;
        }
        // Check for right mouse button up
        else if (Input.GetMouseButtonUp(1))
        {
            _isDragging = false;
        }

        // If dragging, calculate mouse delta and pass it to the camera script
        if (_isDragging)
        {
            var currentMousePosition = Input.mousePosition;
            var mouseDelta = currentMousePosition - _lastMousePosition;
            _lastMousePosition = currentMousePosition;

            // We want the camera to move in the OPPOSITE direction of the mouse drag
            cameraDrag.AddDragVelocity(-mouseDelta);
        }
    }
}
