using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pranckable : MonoBehaviour
{
    [SerializeField] private bool pranked = false;
    [SerializeField] public GameObject point;

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

    private void prank()
    {
        Debug.Log("Grampa Got pranked by: " + this.gameObject.name);
    }

    private void casual()
    {
        Debug.Log("Grampa is interacting with : " + this.gameObject.name);
    }
}
