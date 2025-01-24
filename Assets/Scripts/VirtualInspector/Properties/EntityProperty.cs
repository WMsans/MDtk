using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EntityProperty<T> where T : PropertyValue
{
    public string Identifier;
    public T Value;

    public void SetValue(string value)
    {
        Value.SetValue(value);
    }
    
}
