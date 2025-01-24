using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PropertyValue
{
    public abstract string GetValue();
    public abstract void SetValue(string value);

    public static implicit operator PropertyValue(string value)
    {
        return new StringProperty(value);
    }
    public static implicit operator PropertyValue(int value)
    {
        return new IntProperty(value);
    }
    public static implicit operator PropertyValue(float value)
    {
        return new FloatProperty(value);
    }
}
