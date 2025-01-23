using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Camera))]
public class CameraZoom : MonoBehaviour
{
    public UnityEvent<float> onZoom;
    Camera _camera;

    void Awake()
    {
        _camera = GetComponent<Camera>();
    }
    public void SetZoom(float zoom)
    {
        if(!_camera) _camera = GetComponent<Camera>();
        _camera.orthographicSize = zoom;
        onZoom.Invoke(_camera.orthographicSize);
    }
    public void ChangeZoom(float zoom)
    {
        if(!_camera) _camera = GetComponent<Camera>();
        _camera.orthographicSize += zoom;
        onZoom.Invoke(_camera.orthographicSize);
    }
}
