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
[System.Serializable]
public struct Squance
{
    public string SquanceName;
    public PrankSequance squance;
}
public class GameManager : MonoBehaviour
{
    [Header("Missions")]
    public List<mission> mission;
    [Header("Squances")]
    public List<Squance> Squances;
    public static GameManager This;

    private void Awake()
    {
        This = this;
        foreach(var a in Squances)
        {
            a.squance.Awake();
        }
    }
}
