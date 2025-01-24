using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelectorManager : MonoBehaviour
{
    public static MouseSelectorManager Instance { get; private set; }
    public bool IsSelecting { get; set; } = false;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    public bool IsPointerOverUIElement => !LevelDragTrigger.Instance.Dragable;

    public void SelectEntity(GameObject entity)
    {
        Debug.Log("Selected" + entity.transform.position);
        InspectorManager.Instance.OpenInspector(entity);
    }
}
