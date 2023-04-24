
using System;
using UnityEngine;

[Serializable]
public struct Resource
{
    [SerializeField] private float currentValue;
    [SerializeField] private float maxValue;
    public float CurrentValue => currentValue;
    public float MaxValue => maxValue;

    public Resource(float value)
    {
        if (value > 0)
        {
            maxValue = value;
            currentValue = maxValue;
        }
        else throw new Exception("The value must be greater than zero.");
    }

    public void RestoreMax()
    {
        currentValue = maxValue;
    }
    
    public void IncreaseMax(float value)
    {
        if (value <= 0) return;
        maxValue += value;
    }
    
    public void ReduceMax(float value)
    {
        if (value <= 0) return;
        maxValue -= value;
        if (currentValue > maxValue) currentValue = maxValue;
    }
    
    public void IncreaseCurrent(float value)
    {
        if (value <= 0) return;
        currentValue += value;
        if (currentValue > maxValue) currentValue = maxValue;
    }
    
    public void ReduceCurrent(float value)
    {
        if (value <= 0) return;
        currentValue -= value;
        if (currentValue <= 0f)
        {
            currentValue = 0f;
        }
    }

    public void SetEmpty()
    {
        currentValue = 0f;
    }
    
    public bool GetIsEnough(float value)
    {
        return currentValue - value >= 0;
    }
    
    public bool GetIsEmpty()
    {
        return currentValue == 0f;
    }
}