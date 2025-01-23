using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseScroller : MonoBehaviour
{
    public UnityEvent<float> onScroll;

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f ) // forward
        {
            onScroll.Invoke(Input.GetAxis("Mouse ScrollWheel"));
        }
    }
}
