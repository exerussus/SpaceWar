
using UnityEngine;

[CreateAssetMenu(menuName = "Ship/ShipParameter", fileName = "NewShipParameter")]
public class ShipParameter : ScriptableObject
{
    [SerializeField] private float health;
    [SerializeField] private float armor;
    [SerializeField] private float ammo;

    public float Health => health;
    public float Armor => armor;
    public float Ammo => ammo;
    
}
