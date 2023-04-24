
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    [SerializeField] private WeaponParameter weaponParameter;
    
    public WeaponParameter WeaponParameter => weaponParameter;

    public abstract void Shoot();
}
