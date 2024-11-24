using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(IntegerData))]
public class NumbersEditor : UnityEditor.Editor
{
  public override void OnInspectorGUI()
  {
    IntegerData data = (IntegerData)target;

    GUI.enabled = false;
    EditorGUILayout.ObjectField("Script:", MonoScript.FromScriptableObject(data), typeof(IntegerData), false);
    GUI.enabled = true;

    serializedObject.Update();
    EditorGUILayout.LabelField("Properties for automatic initialization with button below.", EditorStyles.boldLabel);
    data.NumValues = EditorGUILayout.IntField("NumValues", data.NumValues);
    data.MinValue = EditorGUILayout.IntField("MinValue", data.MinValue);
    data.MaxValue = EditorGUILayout.IntField("MaxValue", data.MaxValue);
    data.Randomize = EditorGUILayout.Toggle("Randomize", data.Randomize);

    if (GUILayout.Button("Initialize"))
    {
      data.Init(data.NumValues, data.Randomize);
      EditorUtility.SetDirty(data);
    }

    EditorGUILayout.PropertyField(serializedObject.FindProperty("Data"), true);
    serializedObject.ApplyModifiedProperties();
  }
}
