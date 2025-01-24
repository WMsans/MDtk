using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class EntityPropertyBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI identifierTextMesh;
    [SerializeField] private EntityPropertyValueInputBehaviour valueInputBehaviour;

    public PropertyValue Value
    {
        get => _entity.GetPropertyValue(identifierTextMesh.text);
        set => _entity.SetPropertyValue(identifierTextMesh.text, value);
    }

    public string Identifier => identifierTextMesh.text;
    EntitySelectable _entity;

    public void InitializeBehaviour(string identifier, EntitySelectable entity)
    {
        identifierTextMesh.text = identifier;
        valueInputBehaviour.InitializeBehaviour(this);
        _entity = entity;
    }
    public void SetValue(string value)
    {
        if(value.Length <= 1) return;
        
        Value.SetValue(value);
    }
}
