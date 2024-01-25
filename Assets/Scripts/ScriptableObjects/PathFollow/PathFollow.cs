using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFollow : MonoBehaviour
{
    public List<Vector3> points;
    public int pointIndex = 0;
    public Vector3 destination;
    [SerializeField] private bool loopPath = true;


    private void Update()
    {
        if (pointIndex < points.Count) {
            Vector3 curDestination = points[pointIndex];

            destination = points[pointIndex];

            // IMPORTANT: This doesn't consider the y value of the gameobject (could cause bugs in the future but for now its enough)
            if (Mathf.Floor(transform.position.x) == Mathf.Floor(curDestination.x) && Mathf.Floor(transform.position.z) == Mathf.Floor(curDestination.z)) pointIndex += 1;
        }
        if (pointIndex >= points.Count && loopPath) {
            pointIndex = 0;
        }
    }
}