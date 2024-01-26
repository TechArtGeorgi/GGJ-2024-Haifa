using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct task
{
    public string TaskName;
    public Pranckable prank;
}
[System.Serializable]
public struct mission
{
    public string MissionName;
    public task[] tasks;
}
public class GameManager : MonoBehaviour
{
    public List<mission> mission;
    public static GameManager This;

    private void Awake()
    {
        This = this;
    }
}
