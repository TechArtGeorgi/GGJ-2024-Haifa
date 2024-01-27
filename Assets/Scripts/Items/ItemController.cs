using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using ScriptableObjects;

public class ItemController : Isubject<int>
{
    AnimationsUti uti;
    [SerializeField] private GameEvent gameEvent;

    private void Awake()
    {
        uti = gameObject.GetComponent<AnimationsUti>();
    }
    public void OnViewd()
    {
        if(uti != null) uti.OnMouseEnterAnimation();
        Debug.Log("GameObject :" + this.gameObject.ToString() + " Is Viewd");
    }
    public void OnSelected()
    {
        Debug.Log("GameObject :" + this.gameObject.ToString() + " Is Selected");
        if (uti != null) uti.PlayScaleInAnimation();
        gameEvent.Invoke();
    }
    public void OnReleced()
    {
        if (uti != null) uti.OnMouseExitAnimation();
        Debug.Log("GameObject :" + this.gameObject.ToString() + " Is Releced");
    }
}

