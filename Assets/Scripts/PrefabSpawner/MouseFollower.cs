using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    void Update()
    {
        if (Camera.main != null) transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }   
}
