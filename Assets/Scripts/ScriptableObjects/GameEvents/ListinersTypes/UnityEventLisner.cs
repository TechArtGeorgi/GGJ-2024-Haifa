using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ScriptableObjects;

public class UnityEventLisner : MonoBehaviour, GameEventListener<prank>
{
    [SerializeField] private GameEvent gameEvent;
    [SerializeField] private UnityEvent unityEvent;
    // Start is called before the first frame update
    public void OnEventRaise(prank log)
    {
        unityEvent.Invoke();
    }


    private void OnEnable()
    {
        if (gameEvent != null) gameEvent.AddListener(this);
    }


    private void OnDisable()
    {
        if (gameEvent != null) gameEvent.RemoveListener(this);
    }
}
