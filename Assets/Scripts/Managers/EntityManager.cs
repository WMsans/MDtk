using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntityManager : MonoBehaviour
{
    public static EntityManager Instance { get; private set; }
    public List<EntitySelectable> entities = new List<EntitySelectable>();
    public UnityEvent<EntitySelectable> OnEntityAdded;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    public void AddEntity(EntitySelectable entity)
    {
        entities.Add(entity);
        OnEntityAdded.Invoke(entity);
    }
}
