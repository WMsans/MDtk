using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelDragTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static LevelDragTrigger Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    [SerializeField] private CameraDrag cameraDrag;
    [SerializeField] private float lastMaxDeltaTime = 0.1f;

    private Vector2 _lastMousePosition;
    public bool Dragable { get; private set; } = false;
    public bool IsDragging { get; private set; } = false;
    private float _currentZoom = 1f;
    private Vector2 _lastMaxDelta = Vector2.zero;
    private float _lastMaxDeltaTimer = 0f;
    void Update()
    {
        // Check for right mouse button down
        if (Input.GetMouseButtonDown(1))
        {
            // If the mouse is over this object, we want to start dragging
            if (Dragable) 
            {
                IsDragging = true;
                _lastMousePosition = GetMousePosition();
            }
        }
        // Check for right mouse button up
        else if (Input.GetMouseButtonUp(1))
        {
            if(IsDragging)
            {
                IsDragging = false;
                cameraDrag.AddDragVelocity(-_lastMaxDelta);
            }
        }
        // Get the current zoom
        _currentZoom = Camera.main ? Camera.main.orthographicSize : 1f;
        // If dragging, calculate mouse delta and pass it to the camera script
        if (IsDragging)
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
        Dragable = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Dragable = false;
    }
}
