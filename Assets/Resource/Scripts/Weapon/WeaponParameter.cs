
using System;
using UnityEngine;

[Serializable]
public class WeaponParameter
{
    [SerializeField] private float damage;
    [SerializeField] private float ammoCost;
    [SerializeField] private Sprite icon;
    
    public float Damage => damage;
    public float AmmoCost => ammoCost;
    public Sprite Icon => icon;
}
