using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class EntityPropertyBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI identifierTextMesh;
    [SerializeField] private EntityPropertyValueInputBehaviour valueInputBehaviour;
    public PropertyValue Value => _entity.GetPropertyValue(identifierTextMesh.text);
    public string Identifier => identifierTextMesh.text;
    EntitySelectable _entity;

    public void InitializeBehaviour(string identifier, EntitySelectable entity)
    {
        identifierTextMesh.text = identifier;
        valueInputBehaviour.InitializeBehaviour(this);
        _entity = entity;
    }
}
