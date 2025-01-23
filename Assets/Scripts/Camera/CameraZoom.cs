using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraZoom : MonoBehaviour
{
    Camera _camera;

    void Awake()
    {
        _camera = GetComponent<Camera>();
    }
    public void SetZoom(float zoom)
    {
        if(!_camera) _camera = GetComponent<Camera>();
        _camera.orthographicSize = zoom;
    }
}
