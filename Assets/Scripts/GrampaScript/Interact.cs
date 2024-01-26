using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : Task
{
    [SerializeField] public Pranckable prank;
    SmartSwitch stateSwitch;
    protected override void OnStart()
    {
        prank.interacked();
    }

    protected override void OnStop()
    {
        reset();
    }

    protected override State OnUpdate()
    {
        stateSwitch.Update(prank.IsActive());
        if(stateSwitch.OnRelese())
        {
            return State.Success;
        }
        return State.Running;
    }
}
