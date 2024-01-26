using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ScriptableObjects;

public interface GameEventListener<T>
{
    public abstract void OnEventRaise(T Log);

}
