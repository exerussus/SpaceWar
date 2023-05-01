
using UnityEngine;

[RequireComponent(typeof(ShipResource))]
public class ShipResourceObserver : MonoBehaviour
{
    private ShipResource shipResource;
    [SerializeField] private float health;
    [SerializeField] private float armor;
    [SerializeField] private float ammo;

    private void OnValidate()
    {
        shipResource = shipResource == null ? GetComponent<ShipResource>() : shipResource;
    }

    private void OnEnable()
    {
        Tick.OnFixedUpdate += SetResourceFields;
    }

    private void OnDisable()
    {
        Tick.OnFixedUpdate -= SetResourceFields;
    }

    private void SetResourceFields()
    {
        health = shipResource.CurrentHealth;
        armor = shipResource.CurrentArmor;
        ammo = shipResource.CurrentAmmo;
    }
}
