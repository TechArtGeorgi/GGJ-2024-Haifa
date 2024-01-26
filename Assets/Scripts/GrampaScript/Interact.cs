using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : Task
{
    [SerializeField] public Pranckable prank;
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
          return State.Success;
    }
}
