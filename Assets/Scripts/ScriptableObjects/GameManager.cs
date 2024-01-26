using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;

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
    public GameObject OldMan;
    public SoundEffectSO MainTheme;
    private void Awake()
    {
        OldMan = GameObject.FindGameObjectWithTag("Player");
        MainTheme.Play();
        This = this;
        foreach(var a in Squances)
        {
            a.squance.Awake();
        }
    }
}
