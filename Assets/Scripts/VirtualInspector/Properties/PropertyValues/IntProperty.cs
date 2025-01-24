using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntProperty : PropertyValue
{
    int _value;
    public override string GetValue()
    {
        return _value.ToString();
    }

    public override void SetValue(string value)
    {
        try
        {
            _value = int.Parse(value);
        }
        catch (System.Exception)
        {
            _value = 0;
            Debug.LogWarning("Bad format for int");
        }
    }
}
