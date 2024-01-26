using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class Flag : MonoBehaviour
{
    // The flag indicating whether the condition is met
    public bool conditionMet = false;
    public UnityEvent inform;
    protected SmartSwitch flagSwitch;


    public virtual void resetFlag()
    {
        flagSwitch.Update(false);
        flagSwitch.Update(false);
        conditionMet = false;
    }

    // Abstract method to check the condition
    protected abstract void CheckCondition();

    // Method to update the flag based on the condition
    protected void UpdateFlag()
    {
        CheckCondition();
        // You can add additional logic here if needed
    }

    // Example usage: Check the condition in Update
    protected virtual void Update()
    {
        UpdateFlag();
    }


}
