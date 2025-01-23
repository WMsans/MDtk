using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class DisabledAttribute : PropertyAttribute
{
    public enum MethodLocation { PropertyClass, StaticClass }
    public MethodLocation Location { get; private set; }
    public string MethodName { get; private set; }
    public Type MethodOwnerType { get; private set; }

    public bool? DirectValue { get; private set; }

    public DisabledAttribute(string methodName)
    {
        Location = MethodLocation.PropertyClass;
        MethodName = methodName;
    }

    public DisabledAttribute(Type methodOwner, string methodName)
    {
        Location = MethodLocation.StaticClass;
        MethodOwnerType = methodOwner;
        MethodName = methodName;
    }

    public DisabledAttribute(bool directValue = true)
    {
        DirectValue = directValue;
    }

    public bool? GetDisabled(SerializedProperty property, Type objectType)
    {
        if (DirectValue != null)
        {
            return DirectValue;
        }

        var methodName = MethodName;

        var methodOwnerType = Location == MethodLocation.PropertyClass ? objectType : MethodOwnerType;

        var methodInfo = methodOwnerType.GetMethod
            (methodName,
            BindingFlags.NonPublic
            | BindingFlags.Public
            | BindingFlags.Static
            | BindingFlags.Instance);

        if (methodInfo == null)
        {
            Debug.LogError($"Method {methodName} In {methodOwnerType.FullName} Could Not Be Found!");
            return null;
        }

        var methodInfoReturnValueIsStringArray = methodInfo.ReturnType == typeof(bool);
        if (!methodInfoReturnValueIsStringArray)
        {
            Debug.LogError($"Method {methodName} In {methodOwnerType.FullName} Does Not Have A Return Type Of {typeof(bool).FullName}");
            return null;
        }

        var invokeReference = Location == MethodLocation.StaticClass ? null : property.serializedObject.targetObject;

        var returnValue = methodInfo.Invoke(invokeReference, null) as bool?;

        return returnValue;
    }
}