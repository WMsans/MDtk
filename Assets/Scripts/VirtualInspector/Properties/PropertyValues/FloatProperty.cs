using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatProperty : PropertyValue
{
    float _value;
    public override string GetValue()
    {
        return $"{_value:N2}";
    }

    public override void SetValue(string value)
    {
        try
        {
            _value = float.Parse(value);
        }
        catch (System.Exception)
        {
            _value = 0f;
            Debug.LogWarning("Bad format for float");
        }
    }
    public FloatProperty(float value)
    {
        _value = value;
    }
    public FloatProperty()
    {
        _value = 0f;
    }
}
