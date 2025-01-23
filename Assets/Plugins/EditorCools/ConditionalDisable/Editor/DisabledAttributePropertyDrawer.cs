using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(DisabledAttribute))]
public class DisabledAttributePropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var disabled = ((DisabledAttribute)attribute).GetDisabled(property, fieldInfo.DeclaringType);

        if (disabled == null)
        {
            EditorGUI.LabelField(position, label);
            return;
        }

        EditorGUI.BeginDisabledGroup((bool)disabled);
        EditorGUI.PropertyField(position, property, label, true);
        EditorGUI.EndDisabledGroup();
    }
}
