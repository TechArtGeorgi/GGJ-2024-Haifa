using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFlag : Flag
{
    public void SetFlag()
    {
        conditionMet = true;
        inform.Invoke();
    }
    protected override void CheckCondition()
    {

    }
}
