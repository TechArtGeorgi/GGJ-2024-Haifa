using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    [Header("Lafth Metter")]
    [SerializeField] private Slider LafthSlider;
    private float incroment;
    private void Awake()
    {
        LafthSlider.value = 0.0f;
        OldMan = GameObject.FindGameObjectWithTag("Player");
        MainTheme.Play();
        This = this;
        foreach(var a in Squances)
        {
            a.squance.Awake();
        }
        incroment = 1.0f / Squances.Count;
    }

    public void SuccessfulPrank()
    {
        float value = 0.0f;
        foreach(var a in Squances)
        {
            if (a.squance.prank.pranked == true)
                value += incroment;
        }
        LafthSlider.value = value;
        if (LafthSlider.value >= 0.99f)
        {
            Debug.Log("You Win");
            SceneManager.LoadScene("Credits");
        }
    }
}
