using UnityEngine;
using UnityEngine.Events;

public class Pranckable : MonoBehaviour
{
    [SerializeField] public bool pranked = false;
    [SerializeField] public Vector3 position;
    [SerializeField] public float prankTime = 5.0f;
    [SerializeField] private UnityEvent prankEvents;
    [SerializeField] private UnityEvent CasualEvents;

    [SerializeField] private PrankFlag flag;

    [Header("Animtion")]
    [SerializeField] private int Pranked_Select = 0;
    [SerializeField] private int Casual_Select = 1;
    Timer prankTimer;

    private void Awake()
    {
        flag = GetComponent<PrankFlag>();
    }

    public bool interacked( out int casuel_select, out int prank_select)
    {
        if (pranked) prank();
        else casual();
        casuel_select = Casual_Select; 
        prank_select = Pranked_Select;
        flag.SetFlag();
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
        prankEvents.Invoke();
        Debug.Log("Grampa Got pranked by: " + this.gameObject.name);
        prankTimer.SetTimerTime(prankTime);
        prankTimer.ActivateTimer();
        GameManager.This.SuccessfulPrank();
    }

    private void casual()
    {
        CasualEvents.Invoke();
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
