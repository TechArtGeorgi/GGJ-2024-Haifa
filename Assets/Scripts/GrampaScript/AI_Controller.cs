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
        Interact,
        Rapit
    }
    [SerializeField] private Pranckable coutchPrank;
    [SerializeField] private tasks task = tasks.Idle;
    [SerializeField] private List<GameEvent> EventList;
    [SerializeField] private Move moveTask = new Move();
    [SerializeField] private Interact interactTask = new Interact();
    [SerializeField] private int curMission = 0;
    [SerializeField] private int count = 0;

    [SerializeField] private Animator anim;

    [Header("Movement")]
    [SerializeField] private float speed = 1.0f;
    private Context context;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();

    }

    void OnEnable()
    {
        context = Context.CreateFromGameObject(this.gameObject);
        foreach (var a in EventList)
        {
            a.AddListener(this);
        }
        moveTask.context = context;
        moveTask.speed = speed;
        interactTask.context = context;
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
        count = 0;
        curMission = log.index;
        task = tasks.Move;
        moveTask.Destination = GameManager.This.mission[curMission].tasks[count].prank.position;
        interactTask.prank = GameManager.This.mission[curMission].tasks[count].prank;  
    }

    void Update()
    {
        switch(task)
        {
            case tasks.Move:
                anim.SetBool("Walking", true);
                if (moveTask.eUpdate() != Task.State.Running)
                {
                    anim.SetBool("Walking", false);
                    task = tasks.Interact;
                }
                break;

            case tasks.Interact:
                if (interactTask.eUpdate() != Task.State.Running)
                {
                    task = tasks.Rapit;
                }
                break;
            case tasks.Rapit:
                if(count < GameManager.This.mission[curMission].tasks.Length)
                {
                    
                    task = tasks.Move;
                    moveTask.Destination = GameManager.This.mission[curMission].tasks[count].prank.position;
                    interactTask.prank = GameManager.This.mission[curMission].tasks[count].prank;
                    count++;

                }
                else
                {
                    count = 0;
                    task = tasks.Idle;
                }
                break;

        }
    }    
}

