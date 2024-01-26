using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;


public class AI_Controller : MonoBehaviour, GameEventListener<prank>
{

    [SerializeField] private List<GameEvent> EventList;

    void OnEnable()
    {
        foreach (var a in EventList)
        {
            a.AddListener(this);
        }
    }
    void OnDisable()
    {
        foreach (var a in EventList)
        {
            a.RemoveListener(this);
        }
    }
    public void OnEventRaise(prank log)
    {
        
    }
}

