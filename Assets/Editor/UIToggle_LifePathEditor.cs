using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UIToggle_LifePath),true)]
[CanEditMultipleObjects]
public class UIToggle_LifePathEditor : UnityEditor.UI.ToggleEditor
{
    SerializedProperty m_lifePathProperty;
    protected override void OnEnable()
    {
        base.OnEnable();

        m_lifePathProperty = serializedObject.FindProperty("m_lifePath");
    }
    public override void OnInspectorGUI()
    {

        UIToggle_LifePath component = (UIToggle_LifePath)target;

        base.OnInspectorGUI();

        serializedObject.Update();
        EditorGUILayout.PropertyField(m_lifePathProperty);
        serializedObject.ApplyModifiedProperties();
    }
}
