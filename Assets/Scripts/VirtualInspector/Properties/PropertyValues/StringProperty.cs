using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringProperty : PropertyValue
{
    private string _value;
    public override string GetValue()
    {
        return _value;
    }

    public override void SetValue(string value)
    {
        _value = value;
    }
    public StringProperty(string value)
    {
        _value = value;
    }
    public StringProperty()
    {
        _value = "";
    }
}
