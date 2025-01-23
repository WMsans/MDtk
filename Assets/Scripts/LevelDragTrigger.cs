using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelDragTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private CameraDrag cameraDrag;
    [SerializeField] private float lastMaxDeltaTime = 0.1f;

    private Vector2 _lastMousePosition;
    private bool _dragable = false;
    private bool _isDragging = false;
    private float _currentZoom = 1f;
    private Vector2 _lastMaxDelta = Vector2.zero;
    private float _lastMaxDeltaTimer = 0f;
    void Update()
    {
        // Check for right mouse button down
        if (Input.GetMouseButtonDown(0))
        {
            // If the mouse is over this object, we want to start dragging
            if (_dragable) 
            {
                _isDragging = true;
                _lastMousePosition = GetMousePosition();
            }
        }
        // Check for right mouse button up
        else if (Input.GetMouseButtonUp(0))
        {
            if(_isDragging)
            {
                _isDragging = false;
                cameraDrag.AddDragVelocity(-_lastMaxDelta);
            }
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        _dragable = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _dragable = false;
    }
}
