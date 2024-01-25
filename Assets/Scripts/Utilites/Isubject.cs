using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Isubject<T> : MonoBehaviour
{
    [SerializeField] protected UnityEvent<T> Listeners;
    //protected List<IObserver<T>> Listeners = new List<IObserver<T>>();
    [SerializeField] protected T log;

    public void AddObserver(IObserver<T> op)
    {
        Listeners.AddListener(op.Invoke);
        //Listeners.Add(op);
    }
    public void RemoveObserver(IObserver<T> op)
    {
        Listeners.RemoveListener(op.Invoke);
        //Listeners.Remove(op);
    }

    protected void Invoke()
    {
        Listeners.Invoke(log);
        /*foreach(IObserver<T> a in Listeners)
        {
            a.Invoke(log);
        }*/
    }
}

[System.Serializable]
public struct SensorLog
{
    public int index;
    public Collider col;
    public float Damage;
}

public interface IObserver<T>
{
    void Invoke(T log);   
}



