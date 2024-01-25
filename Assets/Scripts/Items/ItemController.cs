using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : Isubject<int>
{
    public void OnViewd()
    {
        Debug.Log("GameObject :" + this.gameObject.ToString() + " Is Viewd");
    }
    public void OnSelected()
    {
        Debug.Log("GameObject :" + this.gameObject.ToString() + " Is Selected");
        Invoke();
    }
    public void OnReleced()
    {
        Debug.Log("GameObject :" + this.gameObject.ToString() + " Is Releced");
    }
}

