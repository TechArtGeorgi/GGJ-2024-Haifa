using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct task
{
    public string name;
    public Pranckable prank;
}
public class GameManager : MonoBehaviour
{
    public List<task> mission;
    public static GameManager This;

    private void Awake()
    {
        This = this;
    }
}
