using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;


public class AI_Controller : MonoBehaviour, GameEventListener<prank>
{

    enum tasks
    { 
        Idle,
        Move,
        Interact
    }
    [SerializeField] private Pranckable coutchPrank;
    [SerializeField] private tasks task = tasks.Idle;
    [SerializeField] private List<GameEvent> EventList;
    [SerializeField] private Move moveTask;
    [SerializeField] private Interact interactTask;



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
        task = tasks.Move;
        moveTask.Destination = log.gameEvent.position;
        interactTask.prank = GameManager.This.mission[log.index].prank;
    }

    void Update()
    {
        switch(task)
        {
            case tasks.Move:
                if(moveTask.eUpdate() != Task.State.Running)
                {
                    task = tasks.Interact;
                }
                break;

            case tasks.Interact:
                if (interactTask.eUpdate() != Task.State.Running)
                {

                    task = tasks.Idle;
                }
                break;

        }
    }    
}

