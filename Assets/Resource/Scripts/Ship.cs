
using System;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private Resource health = new Resource(100f);
    [SerializeField] private Resource armor = new Resource(50f);
    [SerializeField] private Resource ammo = new Resource(100f);

    public Action OnDead;
    public Action OnTakeDamage;
    
    public void TakeDamage(float damageValue)
    {
        if (armor.GetIsEmpty()) health.ReduceCurrent(damageValue);
        else if (armor.CurrentValue >= damageValue) armor.ReduceCurrent(damageValue);
        else
        {
            var remainingDamage = damageValue - armor.CurrentValue;
            armor.SetEmpty();
            health.ReduceCurrent(remainingDamage);
        }
        OnTakeDamage?.Invoke();
        if (health.GetIsEmpty()) OnDead?.Invoke();
    }

    public bool GetIsEnoughAmmo(float valueCost)
    {
        return ammo.GetIsEnough(valueCost);
    }
    
    public void SpendAmmo(float value)
    {
        ammo.ReduceCurrent(value);
    }
    
    public void RestoreArmor(float value)
    {
        armor.IncreaseCurrent(value);
    }
    
    public void RestoreHealth(float value)
    {
        health.IncreaseCurrent(value);
    }
    
    public void RestoreAmmo(float value)
    {
        ammo.IncreaseCurrent(value);
    }
}
