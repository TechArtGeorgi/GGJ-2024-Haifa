using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task
{
    public enum State
    {
        Running,
        Failure,
        Success
    }

    [HideInInspector] public State state = State.Running;
    [HideInInspector] public Context context;
    private SmartSwitch taskSwitch;
    public void reset()
    {
        state = State.Running;
        taskSwitch.Update(false);
        taskSwitch.Update(false);
    }
    public State eUpdate()
    {
        taskSwitch.Update(state == State.Running);
        if (taskSwitch.OnPress())
        {
            Debug.Log("StartTask "+ToString());
            OnStart();
        }
        if (taskSwitch.OnHold())
        {
            state = OnUpdate();
        }
        if (taskSwitch.OnRelese())
        {
            OnStop();
        }

        return state;
    }
    protected abstract void OnStart();
    protected abstract void OnStop();
    protected abstract State OnUpdate();

}
