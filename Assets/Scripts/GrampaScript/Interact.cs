using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : Task
{
    [SerializeField] public Pranckable prank;
    SmartSwitch stateSwitch;
    [SerializeField] private int causal, pranked;
    protected override void OnStart()
    {
        stateSwitch.Update(false);
        stateSwitch.Update(false);
        if (prank.interacked(out causal, out pranked))
            context.animator.SetInteger("Select", pranked);
        else
            context.animator.SetInteger("Select", causal);
        context.animator.SetTrigger("Special");
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        stateSwitch.Update(context.animator.GetCurrentAnimatorStateInfo(0).IsTag("Special"));
        if (stateSwitch.OnRelese())
        {
            return State.Success;
        }
        return State.Running;
    }
}
