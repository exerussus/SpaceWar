
using System;
using UnityEngine;

public class ShipResource : MonoBehaviour
{
    private Resource _health;
    private Resource _armor;
    private Resource _ammo;

    public float CurrentHealth => _health.CurrentValue;
    public float CurrentArmor => _armor.CurrentValue;
    public float CurrentAmmo => _ammo.CurrentValue;
    public float MaxHealth => _health.MaxValue;
    public float MaxArmor => _armor.MaxValue;
    public float MaxAmmo => _ammo.MaxValue;
    
    public Action OnDead;
    public Action OnTakeDamage;
    public Action OnSpendAmmo;

    public void SetResource(float health, float armor, float ammo)
    {
        _health.SetMax(health);
        _health.RestoreMax();
        _armor.SetMax(armor);
        _armor.RestoreMax();
        _ammo.SetMax(ammo);
        _ammo.RestoreMax();
    }

    public void TakeDamage(float damageValue)
    {
        if (_armor.GetIsEmpty()) _health.ReduceCurrent(damageValue);
        else if (_armor.CurrentValue >= damageValue) _armor.ReduceCurrent(damageValue);
        else
        {
            var remainingDamage = damageValue - _armor.CurrentValue;
            _armor.SetEmpty();
            _health.ReduceCurrent(remainingDamage);
        }
        OnTakeDamage?.Invoke();
        if (_health.GetIsEmpty()) OnDead?.Invoke();
    }

    public bool GetIsEnoughAmmo(float valueCost)
    {
        return _ammo.GetIsEnough(valueCost);
    }
    
    public void SpendAmmo(float value)
    {
        _ammo.ReduceCurrent(value);
        OnSpendAmmo?.Invoke();
    }
    
    public void RestoreArmor(float value)
    {
        _armor.IncreaseCurrent(value);
    }
    
    public void RestoreHealth(float value)
    {
        _health.IncreaseCurrent(value);
    }
    
    public void RestoreAmmo(float value)
    {
        _ammo.IncreaseCurrent(value);
    }
}