#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;


/*public class PranckableEditor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}*/

[CustomEditor(typeof(Pranckable))]
public class PranckableEditor : Editor
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
        if (target is Pranckable pranckable)
        {
            // Draw a wire sphere gizmo at the specified position
            Handles.color = Color.yellow;
            Handles.DrawWireDisc(pranckable.position, Vector3.up, 1f);

            // Allow the user to modify the position using handles
            EditorGUI.BeginChangeCheck();
            Vector3 newPosition = Handles.PositionHandle(pranckable.position, Quaternion.identity);
            if (EditorGUI.EndChangeCheck())
            {
                // If the position has changed, update the GameEvent's position
                Undo.RecordObject(pranckable, "Change GameEvent Position");
                pranckable.position = newPosition;
            }
        }
    }

    public override void OnInspectorGUI()
    {
        // Draw the default inspector
        DrawDefaultInspector();

        // Ensure the target is a GameEvent
        if (target is Pranckable pranckable)
        {
            // Draw a button to reset the position to (0, 0, 0)
            if (GUILayout.Button("Reset Position"))
            {
                Undo.RecordObject(pranckable, "Reset GameEvent Position");
                pranckable.position = Vector3.zero;
            }
        }
    }
}


#endif
