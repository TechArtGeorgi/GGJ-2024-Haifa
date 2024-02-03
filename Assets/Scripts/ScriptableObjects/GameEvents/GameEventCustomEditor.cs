#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using ScriptableObjects;

[CustomEditor(typeof(GameEvent))]
public class GameEventEditor : Editor
{
    private void OnEnable()
    {
        // Subscribe to the scene view update event
        SceneView.duringSceneGui += OnSceneGUI;
    }

    private void OnDisable()
    {
        // Unsubscribe from the scene view update event
        SceneView.duringSceneGui -= OnSceneGUI;
    }

    private void OnSceneGUI(SceneView sceneView)
    {
        // Ensure the target is a GameEvent
        if (target is GameEvent gameEvent)
        {
            // Draw a wire sphere gizmo at the specified position
            Handles.color = Color.yellow;
            Handles.DrawWireDisc(gameEvent.position, Vector3.up, 1f);

            // Allow the user to modify the position using handles
            EditorGUI.BeginChangeCheck();
            Vector3 newPosition = Handles.PositionHandle(gameEvent.position, Quaternion.identity);
            if (EditorGUI.EndChangeCheck())
            {
                // If the position has changed, update the GameEvent's position
                Undo.RecordObject(gameEvent, "Change GameEvent Position");
                gameEvent.position = newPosition;
            }
        }
    }

    public override void OnInspectorGUI()
    {
        // Draw the default inspector
        DrawDefaultInspector();

        // Ensure the target is a GameEvent
        if (target is GameEvent gameEvent)
        {
            // Draw a button to reset the position to (0, 0, 0)
            if (GUILayout.Button("Reset Position"))
            {
                Undo.RecordObject(gameEvent, "Reset GameEvent Position");
                gameEvent.position = Vector3.zero;
            }
            if (GUILayout.Button("Debug"))
            {
                gameEvent.Invoke();
            }
        }
    }
}
//[CustomEditor(typeof(GameEvent))]
/*public class GameEventCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GameEvent ge = (GameEvent)target;
        if (GUILayout.Button("Invoke"))
        {
            ge.Invoke();
        }
    }
}*/
#endif
