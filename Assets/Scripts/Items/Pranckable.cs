using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pranckable : MonoBehaviour
{
    [SerializeField] public bool pranked = false;
    [SerializeField] public Vector3 position;
    [SerializeField] public float prankTime = 5.0f;
    [SerializeField] private UnityEvent prankEvents;
    [SerializeField] private UnityEvent CasualEvents;

    [Header("Animtion")]
    [SerializeField] private int PrankedSelect = 0;
    [SerializeField] private int casualedPrankedSelect = 1;
    Timer prankTimer;

    public bool interacked( out int casuel_select, out int prank_select)
    {
        if (pranked) prank();
        else casual();
        casuel_select = casualedPrankedSelect; 
        prank_select = PrankedSelect;
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

    public void resetPrank()
    {
        pranked = false;
    }

    private void prank()
    {
        Debug.Log("Grampa Got pranked by: " + this.gameObject.name);
        prankTimer.SetTimerTime(prankTime);
        prankTimer.ActivateTimer();
        GameManager.This.SuccessfulPrank();
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
