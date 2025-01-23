using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDragTrigger : MonoBehaviour
{
    [SerializeField] private CameraDrag cameraDrag;

    private Vector2 _lastMousePosition;
    private bool _isDragging = false;
    private float _currentZoom = 1f;

    void Update()
    {
        // Check for right mouse button down
        if (Input.GetMouseButtonDown(1))
        {
            _isDragging = true;
            _lastMousePosition = GetMousePosition();
        }
        // Check for right mouse button up
        else if (Input.GetMouseButtonUp(1))
        {
            _isDragging = false;
        }
        // Get the current zoom
        _currentZoom = Camera.main ? Camera.main.orthographicSize : 1f;
        // If dragging, calculate mouse delta and pass it to the camera script
        if (_isDragging)
        {
            var currentMousePosition = GetMousePosition();
            var mouseDelta = currentMousePosition - _lastMousePosition;
            _lastMousePosition = currentMousePosition;

            // We want the camera to move in the OPPOSITE direction of the mouse drag
            cameraDrag.AddDragVelocity(-mouseDelta);
        }
    }

    private Vector2 GetMousePosition()
    {
        return Input.mousePosition * _currentZoom;
    }
}
