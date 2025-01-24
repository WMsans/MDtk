using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadEntityProperties : MonoBehaviour
{
    [SerializeField] private GameObject entityPropertyPrefab;
    private void Start()
    {
        InspectorManager.Instance.OnEntitySelected.AddListener(LoadProperties);
        InspectorManager.Instance.OnEntityDeselected.AddListener(UnloadProperties);
    }

    private void LoadProperties(EntitySelectable entity)
    {
        UnloadProperties();
        Debug.Log("Loading properties for " + entity.name);
        foreach (var property in entity.properties)
        {
            var entityPropertyObject = Instantiate(entityPropertyPrefab, transform);
            var behaviour = entityPropertyObject.GetComponent<EntityPropertyBehaviour>();
            behaviour.InitializeBehaviour(property.Identifier, entity);
        }
    }

    public void UnloadProperties()
    {
        Debug.Log("Unloading properties");
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
