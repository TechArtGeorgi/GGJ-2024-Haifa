
[System.Serializable]
public class FloatReference
{
    public bool useConstant = true;
    public float constantValue;
    public FloatVariable variable;

    public float value
    {
        get
        {
            return useConstant ? constantValue : variable.value;
        }
    }
    public void SetValue(float newVal)
    {
        variable.value = newVal;
    }
    
}
