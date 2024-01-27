using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class PrankSequance 
{
    public Pranckable prank;
    public List<Flag> boolList;
    private int currentIndex = 0;

    public void Awake()
    {
        foreach (var a in boolList)
        {
            a.inform.AddListener(checkSquance);
        }
    }
    private bool InSquance()
    {
        for(int i = currentIndex+1;  i < boolList.Count; i++)
        {
            if(boolList[i].conditionMet != false)
            {
                currentIndex = 0;
                return false;
            }
        }
        currentIndex++;
        return true;
    }
    
    public void checkSquance(Flag f)
    {
        if(f.conditionMet == true)
        {
            foreach (var a in boolList)
            {
                a.resetFlag();
            }
            //return;
        }

        if(InSquance() == false)
        {
            foreach(var a in boolList)
            {
                a.resetFlag();
            }
            //return;
        }
        if(currentIndex == boolList.Count)
        {
            prank.pranked = true;
            foreach (var a in boolList)
            {
                a.resetFlag();
            }
        }
    }

}
