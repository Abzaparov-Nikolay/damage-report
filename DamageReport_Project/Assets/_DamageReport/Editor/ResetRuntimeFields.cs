using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;
using System.Linq;
using System.Collections.Generic;

[InitializeOnLoad]
public static class ResetRuntimeFields
{
    static ResetRuntimeFields()
    {
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.EnteredEditMode)
        {
            foreach (var runtimeObject in FindRuntimeObjects())
            {
                ResetFields(runtimeObject);
            }
        }
    }

    private static IEnumerable<object> FindRuntimeObjects()
    {
        List<object> objects = new();
        var guids = AssetDatabase.FindAssets("t:ScriptableObject", new[] { "Assets/_DamageReport/RuntimeSO" });
        foreach (var guid in guids)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            objects.Add(AssetDatabase.LoadAssetAtPath<ScriptableObject>(path));
        }
        return objects;
    }

    private static void ResetFields(object caller)
    {
        foreach (var field in caller.GetType().GetFields(
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
        {
            var runtimeExplicit = HasAttributes(field, typeof(RuntimeRWAttribute), typeof(RuntimeROAttribute));
            var notSerializedByDefault = (field.IsPrivate || field.IsFamily) 
                && !HasAttributes(field, typeof(SerializeField));
            if (runtimeExplicit || notSerializedByDefault)
            {
                var defaultValue = field.FieldType.IsValueType ? Activator.CreateInstance(field.FieldType) : null;
                field.SetValue(caller, defaultValue);
            }
        }


        static bool HasAttributes(FieldInfo field, params Type[] attributes)
        {
            return field.CustomAttributes.Any(attr => attributes.Contains(attr.AttributeType));
        }
    }
}
