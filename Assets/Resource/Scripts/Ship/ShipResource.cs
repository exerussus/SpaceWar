using System;
using UnityEngine;

public class ShipResource : MonoBehaviour
{
    [SerializeField] private Resource health = new Resource(100f);
    [SerializeField] private Resource armor = new Resource(50f);
    [SerializeField] private Resource ammo = new Resource(100f);

    public Resource Health => health;
    public Resource Armor => armor;
    public Resource Ammo => ammo;
    
    public Action OnDead;
    public Action OnTakeDamage;

    public void SetResource(float health, float armor, float ammo)
    {
        this.health.SetMax(health);
        this.health.RestoreMax();
        this.armor.SetMax(armor);
        this.armor.RestoreMax();
        this.ammo.SetMax(ammo);
        this.ammo.RestoreMax();
    }

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