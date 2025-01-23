using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDragTrigger : MonoBehaviour
{
    [SerializeField] private CameraDrag cameraDrag;
    [SerializeField] private float lastMaxDeltaTime = 0.1f;

    private Vector2 _lastMousePosition;
    private bool _isDragging = false;
    private float _currentZoom = 1f;
    private Vector2 _lastMaxDelta = Vector2.zero;
    private float _lastMaxDeltaTimer = 0f;

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
            cameraDrag.AddDragVelocity(-_lastMaxDelta);
        }
        // Get the current zoom
        _currentZoom = Camera.main ? Camera.main.orthographicSize : 1f;
        // If dragging, calculate mouse delta and pass it to the camera script
        if (_isDragging)
        {
            var currentMousePosition = GetMousePosition();
            var mouseDelta = currentMousePosition - _lastMousePosition;
            if (mouseDelta.sqrMagnitude > _lastMaxDelta.sqrMagnitude || Time.time - _lastMaxDeltaTimer > lastMaxDeltaTime)
            {
                _lastMaxDelta = mouseDelta;
                _lastMaxDeltaTimer = Time.time;
            }
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
