using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FloatVariable", menuName = "Floats/Float Variable")]
public class FloatVariable : ScriptableObject
{
    public float value;
    private float resetValue;

    private void OnEnable()
    {
        Debug.Log("sfssds" + resetValue);
        resetValue = value;
    }
    private void OnDisable()
    {
        Debug.Log("sfssdsefsveger" + resetValue);
        value = resetValue;
    }

    void Reset()
    {
        Debug.Log("Reset");
    }
}
