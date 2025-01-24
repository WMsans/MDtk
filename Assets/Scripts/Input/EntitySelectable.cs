using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySelectable : MonoBehaviour
{
    public bool IsHovered { get; private set; } = false;
    private void OnMouseOver()
    {
        IsHovered = true;
        MouseSelectorManager.Instance.IsSelecting = true;
    }
    private void OnMouseExit()
    {
        IsHovered = false;
        MouseSelectorManager.Instance.IsSelecting = false;
    }

    private void OnMouseDown()
    {
        if (IsHovered)
        {
            MouseSelectorManager.Instance.SelectEntity(gameObject);
        }
    }
}
