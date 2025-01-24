using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectorManager : MonoBehaviour
{
    public static InspectorManager Instance { get; private set; }
    public GameObject inspector;
    [SerializeField] private LineRenderer lineRenderer;
    private bool _isSelecting;
    private EntitySelectable _selectedEntity;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public void CloseInspector()
    {
        inspector.SetActive(false);
        _isSelecting = false;
        _selectedEntity.OnDeselected();
        _selectedEntity = null;
    }
    public void OpenInspector(EntitySelectable entity)
    {
        inspector.SetActive(true);
        _isSelecting = true;
        if(_selectedEntity) _selectedEntity.OnDeselected();
        _selectedEntity = entity;
        _selectedEntity.OnSelected();
    }

    private void Update()
    {
        HandleLineRenderer();
    }

    private void HandleLineRenderer()
    {
        if (_isSelecting)
        {
            lineRenderer.SetPosition(0, _selectedEntity.transform.position);
            lineRenderer.SetPosition(1, (Vector2)Camera.main.ScreenToWorldPoint(inspector.transform.position));
        }
        else
        {
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, Vector3.zero);
        }
    }
}
