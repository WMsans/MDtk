using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportManager : MonoBehaviour
{
    public static TeleportManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    Camera _camera;
    public UnityEvent<Vector2> onTeleport;

    void Start()
    {
        if (!_camera) _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    public void Teleport(Vector2 position)
    {
        _camera.transform.position = position;
    }

    public void TeleportX(string positionX)
    {
        if (Camera.main != null)
            try
            {
                _camera.transform.position = new(float.Parse(positionX), _camera.transform.position.y,
                    _camera.transform.position.z);
            }
            catch (System.Exception)
            {
                // ignored
            }

        onTeleport.Invoke(_camera.transform.position);
    }

    public void TeleportY(string positionY)
    {
        if (Camera.main != null)
            try
            {
                _camera.transform.position = new(_camera.transform.position.x, float.Parse(positionY),
                    _camera.transform.position.z);
            }
            catch (System.Exception)
            {
                // ignored
            }

        onTeleport.Invoke(_camera.transform.position);
    }
}
