using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityList : MonoBehaviour
{
    [SerializeField] private GameObject entityListItemPrefab;

    private void Start()
    {
        EntityManager.Instance.OnEntityAdded.AddListener(AddEntity);
    }
    private void AddEntity(EntitySelectable entity)
    {
        var entityListItem = Instantiate(entityListItemPrefab, transform);
        var behaviour = entityListItem.GetComponent<EntityListItem>();
        behaviour.Entity = entity;
    }

    private void ClearList()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
    private void FetchEntities()
    {
        ClearList();
        var entities = EntityManager.Instance.entities;
        foreach (var entity in entities)
        {
            AddEntity(entity);
        }
    }
    private void OnEnable()
    {
        FetchEntities();
    }
}
