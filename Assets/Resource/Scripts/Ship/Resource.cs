
using System;

[Serializable]
public struct Resource
{
    private float _currentValue;
    private float _maxValue;
    public float CurrentValue => _currentValue;
    public float MaxValue => _maxValue;

    public Resource(float value)
    {
        if (value > 0)
        {
            _maxValue = value;
            _currentValue = _maxValue;
        }
        else throw new Exception("The value must be greater than zero.");
    }

    public void RestoreMax()
    {
        _currentValue = _maxValue;
    }
    
    public void SetMax(float value)
    {
        if (value <= 0) return;
        _maxValue = value;
    }
    
    public void IncreaseMax(float value)
    {
        if (value <= 0) return;
        _maxValue += value;
    }
    
    public void ReduceMax(float value)
    {
        if (value <= 0) return;
        _maxValue -= value;
        if (_currentValue > _maxValue) _currentValue = _maxValue;
    }
    
    public void IncreaseCurrent(float value)
    {
        if (value <= 0) return;
        _currentValue += value;
        if (_currentValue > _maxValue) _currentValue = _maxValue;
    }
    
    public void ReduceCurrent(float value)
    {
        if (value <= 0) return;
        _currentValue -= value;
        if (_currentValue <= 0f)
        {
            _currentValue = 0f;
        }
    }

    public void SetEmpty()
    {
        _currentValue = 0f;
    }
    
    public bool GetIsEnough(float value)
    {
        return _currentValue - value >= 0;
    }
    
    public bool GetIsEmpty()
    {
        return _currentValue == 0f;
    }
}