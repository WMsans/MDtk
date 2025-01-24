using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class InspectorManager : MonoBehaviour
{
    public static InspectorManager Instance { get; private set; }
    public GameObject inspector;
    [SerializeField] private LineRenderer lineRenderer;
    public UnityEvent<EntitySelectable> OnEntitySelected;
    public UnityEvent OnEntityDeselected;
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

    private void Start()
    {
        CloseInspector();
    }
    public void CloseInspector()
    {
        OnEntityDeselected.Invoke();
        inspector.SetActive(false);
        _isSelecting = false;
        if(!_selectedEntity) return;
        _selectedEntity.OnDeselected();
        _selectedEntity = null;
    }
    public void OpenInspector(EntitySelectable entity)
    {
        inspector.SetActive(true);
        _isSelecting = true;
        if(_selectedEntity)
        {
            _selectedEntity.OnDeselected();
            if (entity == _selectedEntity)
            {
                CloseInspector();
                return;
            }
        }
        _selectedEntity = entity;
        _selectedEntity.OnSelected();
        OnEntitySelected.Invoke(_selectedEntity);
    }
    private void Update()
    {
        HandleLineRenderer();
    }

    private void HandleLineRenderer()
    {
        if (_isSelecting)
        {
            lineRenderer.enabled = true; 
            DOTween.To(() => lineRenderer.GetPosition(0), x => lineRenderer.SetPosition(0, x), _selectedEntity.transform.position, 0.25f);
            //lineRenderer.SetPosition(0, _selectedEntity.transform.position);
            lineRenderer.SetPosition(1, (Vector2)Camera.main.ScreenToWorldPoint(inspector.transform.position));
        }
        else
        {
            lineRenderer.enabled = false;
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, Vector3.zero);
        }
    }
}
