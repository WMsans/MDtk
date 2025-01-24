using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectorManager : MonoBehaviour
{
    public static InspectorManager Instance { get; private set; }
    public GameObject inspector;
    [SerializeField] private LineRenderer lineRenderer;
    private bool _isSelecting;
    private GameObject _selectedEntity;
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
        _selectedEntity = null;
    }
    public void OpenInspector(GameObject entity)
    {
        inspector.SetActive(true);
        _isSelecting = true;
        _selectedEntity = entity;
    }

    private void Update()
    {
        if (_isSelecting)
        {
            lineRenderer.SetPosition(0, _selectedEntity.transform.position);
            lineRenderer.SetPosition(1, (Vector2)Camera.main.ScreenToWorldPoint(inspector.transform.position));
        }
    }
}
