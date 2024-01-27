using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrankFlag : Flag
{
    [SerializeField] private Pranckable prank;
    
    private void OnEnable()
    {
        prank = GetComponent<Pranckable>();
    }
    protected override void CheckCondition()
    {
        /*if (prank != null)
        {
            flagSwitch.Update(prank.IsActive());
            if (flagSwitch.OnPress())
            {
                conditionMet = true;
                inform.Invoke();
            }
        }*/
    }
}
