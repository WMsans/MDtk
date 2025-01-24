using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using EPOOutline;
using UnityEngine;
using UnityEngine.Serialization;

public class EntitySelectable : MonoBehaviour
{
    private Outlinable _outlinable;
    public bool IsHovered { get; private set; } = false;

    public List<EntityProperty<PropertyValue>> properties /*{ get; private set; }*/ = new()
    {
        new()
        {
            Identifier = "Name",
            Value = new StringProperty("EntityName")
        }
    };

    private void Start()
    {
        _outlinable = GetComponent<Outlinable>();
    }
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
        if (IsHovered && !MouseSelectorManager.Instance.IsPointerOverUIElement)
        {
            SelectThis();
        }
    }

    public void SelectThis()
    {
        MouseSelectorManager.Instance.SelectEntity(this);
    }
    public void OnSelected()
    {
        SetOutline(true);
    }
    public void OnDeselected()
    {
        SetOutline(false);
    }
    public void AddProperty(EntityProperty<PropertyValue> property)
    {
        properties.Add(property);
    }
    public void RemoveProperty(int index)
    {
        properties.RemoveAt(index);
    }

    public PropertyValue GetPropertyValue(string identifier)
    {
        return properties.Find(x => x.Identifier == identifier).Value;
    }
    public void SetPropertyValue(string identifier, PropertyValue value)
    {
        var property = properties.Find(x => x.Identifier == identifier);
        property.Value = value;
    }
    private void SetOutline(bool active)
    {
        if (active)
        {
            if(_outlinable.OutlineParameters.Enabled) return;
            _outlinable.OutlineParameters.Enabled = true;
            _outlinable.OutlineParameters.Color = new(_outlinable.OutlineParameters.Color.r, _outlinable.OutlineParameters.Color.g, _outlinable.OutlineParameters.Color.b, 0f);
            DOTween.To(() => _outlinable.OutlineParameters.Color.a, x => _outlinable.OutlineParameters.Color = new(_outlinable.OutlineParameters.Color.r, _outlinable.OutlineParameters.Color.g, _outlinable.OutlineParameters.Color.b, x), 1f, 0.25f);
        }
        else
        {
            if (!_outlinable.OutlineParameters.Enabled) return;
            DOTween.To(() => _outlinable.OutlineParameters.Color.a, x => _outlinable.OutlineParameters.Color = new(_outlinable.OutlineParameters.Color.r, _outlinable.OutlineParameters.Color.g, _outlinable.OutlineParameters.Color.b, x), 0f, 0.25f).OnComplete(() => _outlinable.OutlineParameters.Enabled = false);
        }
    }
}
