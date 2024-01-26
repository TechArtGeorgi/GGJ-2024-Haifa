using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pranckable : MonoBehaviour
{
    [SerializeField] public bool pranked = false;
    [SerializeField] public Vector3 position;
    [SerializeField] public float prankTime = 5.0f;
    Timer prankTimer;
    

    public bool interacked()
    {
        if (pranked)    prank();
        else            casual();

        return pranked;
    }

    public void triggerPrank()
    {
        pranked = true;
    }

    public bool IsActive()
    {
        return prankTimer.IsTimerActive();
    }

    private void prank()
    {
        Debug.Log("Grampa Got pranked by: " + this.gameObject.name);
        prankTimer.SetTimerTime(prankTime);
        prankTimer.ActivateTimer();
    }

    private void casual()
    {
        Debug.Log("Grampa is interacting with : " + this.gameObject.name);
        prankTimer.SetTimerTime(prankTime);
        prankTimer.ActivateTimer();
    }

    public void Update()
    {
        if(prankTimer.IsTimerActive())
            prankTimer.SubtractTimerByValue(Time.deltaTime);
    }
}
