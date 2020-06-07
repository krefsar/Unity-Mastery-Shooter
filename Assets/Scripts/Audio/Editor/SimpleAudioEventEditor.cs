using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SimpleAudioEvent))]
public class SimpleAudioEventEditor : Editor
{
    private AudioSource previewSource;

    private void OnEnable()
    {
        var audioObject = EditorUtility.CreateGameObjectWithHideFlags(
            "Audio Preview",
            HideFlags.HideAndDontSave,
            typeof(AudioSource));

        previewSource = audioObject.GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        DestroyImmediate(previewSource.gameObject);
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);

        if (GUILayout.Button("Preview"))
        {
            SimpleAudioEvent simpleTarget = (SimpleAudioEvent)target;
            simpleTarget.Play(previewSource);
        }

        EditorGUI.EndDisabledGroup();
    }
}
