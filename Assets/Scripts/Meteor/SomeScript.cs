using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SomeScript))]
public class SomeScript : MonoBehaviour
{
    public int level;
    public float health;
    public Vector3 target;
}

public class SomeScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.HelpBox("This is a help box", MessageType.Info);
    }
}
