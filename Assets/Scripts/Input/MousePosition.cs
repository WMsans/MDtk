using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MousePosition : MonoBehaviour
{
    public UnityEvent<Vector2> onMouseMove;
    public UnityEvent<string> onMouseMoveX;
    public UnityEvent<string> onMouseMoveY;

    private void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Mouse X")) > 0.1f || Mathf.Abs(Input.GetAxis("Mouse Y")) > 0.1f)
        {
            onMouseMove.Invoke(new(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")));
        }
        if (Camera.main == null) return;
        onMouseMoveX.Invoke("X: " + $"{Camera.main.ScreenToWorldPoint(Input.mousePosition).x:N2}");
        onMouseMoveY.Invoke("Y: " + $"{Camera.main.ScreenToWorldPoint(Input.mousePosition).y:N2}");
    }
}
