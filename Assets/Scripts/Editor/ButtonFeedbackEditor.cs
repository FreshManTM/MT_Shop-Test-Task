using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ButtonFeedback))]
public sealed class ButtonFeedbackEditor : Editor
{
    SerializedProperty _useHighlightScale;
    SerializedProperty _highlightScale;

    SerializedProperty _usePressScale;
    SerializedProperty _pressedScale;

    SerializedProperty _scaleSpeed;

    void OnEnable()
    {
        _useHighlightScale = serializedObject.FindProperty("_useHighlightScale");
        _highlightScale = serializedObject.FindProperty("_highlightScale");

        _usePressScale = serializedObject.FindProperty("_usePressScale");
        _pressedScale = serializedObject.FindProperty("_pressedScale");

        _scaleSpeed = serializedObject.FindProperty("_scaleSpeed");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(_useHighlightScale);

        if (_useHighlightScale.boolValue)
            EditorGUILayout.PropertyField(_highlightScale);

        EditorGUILayout.Space(4);

        EditorGUILayout.PropertyField(_usePressScale);

        if (_usePressScale.boolValue)
            EditorGUILayout.PropertyField(_pressedScale);

        EditorGUILayout.Space(6);

        EditorGUILayout.PropertyField(_scaleSpeed);

        serializedObject.ApplyModifiedProperties();
    }
}
