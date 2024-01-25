using UnityEngine;
using UnityEditor;
using ScriptableObjects;

[CustomEditor(typeof(GameEvent))]
public class GameEventCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GameEvent ge = (GameEvent)target;
        if (GUILayout.Button("Invoke"))
        {
            ge.Raise();
        }
    }
}

