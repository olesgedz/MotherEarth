using UnityEngine;
using UnityEditor;

public class LayerTagsManager : EditorWindow
{
    Vector2 scrollPos;
    SerializedObject tagManager;

    [MenuItem("Window/Open My Tags and Layers Window")]
    static void OpenTagsEditorWindow()
    {
        LayerTagsManager window = EditorWindow.GetWindow<LayerTagsManager>("Tags & Layers");
        window.tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
    }

    void OnGUI()
    {
        EditorGUIUtility.LookLikeInspector();
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
        SerializedProperty it = tagManager.GetIterator();
        bool showChildren = true;
        while (it.NextVisible(showChildren))
        {
            // if (it.name == "data") <-- It's a tag property
            // if (it.name.Contains ("Layer")) <-- It's a layer property
            showChildren = EditorGUILayout.PropertyField(it);
        }
        EditorGUILayout.EndScrollView();
    }
}